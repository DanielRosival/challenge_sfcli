using RestSharp;
using sfcli.Commands;
using sfcli.Dto;
using sfcli.Exceptions;
using sfcli.Services.Abstractions;
using sfcli.SmartfaceClient.Abstractions;

namespace sfcli.Services;

public class GetService : IGetService
{
    private readonly ISmartfaceClient _sfClient;
    private readonly ILogger<CreateWatchlistService> _logger;

    public GetService(
        ISmartfaceClient sfClient,
        ILogger<CreateWatchlistService> logger
        )
    {
        _sfClient = sfClient;
        _logger = logger;
    }

    public async Task<RestResponse> RunService(object opts)
    {
        var options = opts as GetOptions;
        if (options == null)
        {
            throw new InvalidArgsException("Command line args are null, maybe not parsable");
        }

        return await _sfClient.GetAllWatchlistsAsync();
    }    
}