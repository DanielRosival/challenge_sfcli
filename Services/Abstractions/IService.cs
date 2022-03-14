using RestSharp;

namespace sfcli.Services.Abstractions;

public interface IService
{
    Task<RestResponse> RunService(object opts);
}