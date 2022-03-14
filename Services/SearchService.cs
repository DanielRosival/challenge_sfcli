using System.IO.Abstractions;
using RestSharp;
using sfcli.Commands;
using sfcli.Dto;
using sfcli.Exceptions;
using sfcli.Services.Abstractions;
using sfcli.SmartfaceClient.Abstractions;

namespace sfcli.Services;

public class SearchService : ISearchService, IService
{
    protected readonly IFileSystem _fileSystem;
    private readonly ISmartfaceClient _sfClient;
    private readonly ILogger<SearchService> _logger;

    public SearchService(
        IFileSystem fileSystem,
          ISmartfaceClient sfClient,
          ILogger<SearchService> logger
        )
    {
        _fileSystem = fileSystem;
        _sfClient = sfClient;
        _logger = logger;
    }

    public async Task<RestResponse> RunService(object opts)
    {
        var options = opts as SearchOptions;
        if (options == null)
        {
            throw new InvalidArgsException("Command line args are null, maybe not parsable");
        }

        CheckOptions(options);
        CheckFilePath(options.PathToFile);

        var dto = new SearchWatchlistDto()
        {
            Image = await LoadFile(options.PathToFile) ,
            WatchlistIds = new List<string>() { options.WatchlistId.ToString() },
            FaceDetectorConfig = new FaceDetectorConfig() 
            {
                MinFaceSize = options.MinFaceSize,
                MaxFaceSize = options.MaxFaceSize
            },
            Threshold = options.Treshold,
            FaceFeaturesConfig = new FaceFeaturesConfig(),
            FaceMaskConfidenceRequest = new FaceMaskConfidenceRequest()
        };
        return await _sfClient.SearchWatchlist(dto);
    }

    private async Task<Image> LoadFile(string pathToFile)
    {
        var fullPath = _fileSystem.Path.GetFullPath(pathToFile);

        byte[] imageArray = await _fileSystem.File.ReadAllBytesAsync(fullPath);

        return new Image() { Data = Convert.ToBase64String(imageArray) };
    }

    private void CheckFilePath(string pathToFile)
    {
        var fullPath = _fileSystem.Path.GetFullPath(pathToFile);
        if (!_fileSystem.File.Exists(fullPath))
        {
            throw new FileNotFoundException($"File {pathToFile} not found.");
        }
    }

    private void CheckOptions(SearchOptions options)
    {
        if (options.WatchlistId == Guid.Empty)
        {
            throw new InvalidArgsException("WatchlistId -w missing");
        }

        if (string.IsNullOrEmpty(options.PathToFile))
        {
            throw new InvalidArgsException("PathToFile -p missing");
        }
    }
}