using RestSharp;
using sfcli.Dto;

namespace sfcli.SmartfaceClient.Abstractions;

public interface ISmartfaceClient
{
    Task<RestResponse> CreateWatchlistAsync(CreateWatchlistRequestDto data);
    Task<RestResponse> GetAllWatchlistsAsync();
    Task<CreateWatchlistMemberResponseDto?> CreateWatchlistMemberAsync(CreateWatchlistMemberRequestDto data);
    Task<RestResponse> RegisterMemberAsync(RegisterMemberRequestDto data);
    Task<RestResponse> SearchWatchlist(SearchWatchlistDto data);
}
