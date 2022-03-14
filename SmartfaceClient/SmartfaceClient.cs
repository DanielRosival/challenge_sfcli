using System.Net;
using RestSharp;
using RestSharp.Serializers;
using sfcli.Dto;
using sfcli.SmartfaceClient.Abstractions;

namespace sfcli.SmartfaceClient;

public class SmartfaceClient : ISmartfaceClient, IDisposable
{

    private readonly RestClient _client;
    private readonly ILogger<SmartfaceClient> _logger;


    public SmartfaceClient(
        IConfiguration configuration,
        ILogger<SmartfaceClient> logger
        )
    {
        var sfConfig = configuration.GetSection("SmartfaceConfig");
        var options = new RestClientOptions(sfConfig["BaseUrl"]);
        _client = new RestClient(options);

        _logger = logger;
    }

    public async Task<RestResponse> CreateWatchlistAsync(CreateWatchlistRequestDto data)
    {
        var request = new RestRequest("Watchlists");
        request.AddJsonBody(data);

        return await _client.ExecutePostAsync(request);
    }

    public async Task<RestResponse> GetAllWatchlistsAsync()
    {
        var request = new RestRequest("Watchlists")
            .AddParameter("ShowTotalCount", true); ;

        return await _client.ExecuteGetAsync(request);
    }

    public async Task<CreateWatchlistMemberResponseDto?> CreateWatchlistMemberAsync(CreateWatchlistMemberRequestDto data)
    {
        var request = new RestRequest("WatchlistMembers")
            .AddJsonBody(data);
        try
        {
            return await _client.PostAsync<CreateWatchlistMemberResponseDto>(request);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
            return null;
        }
    }

    public async Task<RestResponse> RegisterMemberAsync(RegisterMemberRequestDto data)
    {
        var request = new RestRequest("WatchlistMembers/Register")
            .AddJsonBody(data);

        return await _client.ExecutePostAsync(request);
    }

    public async Task<RestResponse> SearchWatchlist(SearchWatchlistDto data)
    {
        var request = new RestRequest("Watchlists/Search")
            .AddJsonBody(data);

        return await _client.ExecutePostAsync(request);
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }


}