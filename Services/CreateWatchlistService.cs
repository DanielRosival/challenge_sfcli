using RestSharp;
using sfcli.Commands;
using sfcli.Dto;
using sfcli.Exceptions;
using sfcli.Services.Abstractions;
using sfcli.SmartfaceClient.Abstractions;

namespace sfcli.Services;

public class CreateWatchlistService : ICreateWatchlistService
{
    private readonly ISmartfaceClient _sfClient;
    private readonly ILogger<CreateWatchlistService> _logger;

    public CreateWatchlistService(
        ISmartfaceClient sfClient,
        ILogger<CreateWatchlistService> logger
        )
    {
        _sfClient = sfClient;
        _logger = logger;
    }

    public async Task<RestResponse> RunService(object opts)
    {
        var options = opts as CreateOptions;
        if (options == null)
        {
            throw new InvalidArgsException("Command line args are null, maybe not parsable");
        }

        CheckOptions(options);

        var dto = new CreateWatchlistRequestDto()
        {
            FullName = options.FullName,
            DisplayName = options.DisplayName,
            Threshold = options.Treshold,
            PreviewColor = options.PreviewColor
        };
        
        return await _sfClient.CreateWatchlistAsync(dto);
    }

    private void CheckOptions(CreateOptions options)
    {
        if (string.IsNullOrEmpty(options.DisplayName))
        {
            throw new InvalidArgsException("DisplayName -d missing");
        }
        
        if (string.IsNullOrEmpty(options.FullName))
        {
            throw new InvalidArgsException("FullName -d missing");
        }

        if (string.IsNullOrEmpty(options.PreviewColor))
        {
            throw new InvalidArgsException("PreviewColor -d missing");
        }

        if (!(options.Treshold > 0 && options.Treshold <= 100))
        {
            throw new InvalidArgsException("Invalid range of threshold, should be (0-100>");
        }
    }
}