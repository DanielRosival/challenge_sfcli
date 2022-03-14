using System.IO.Abstractions;
using RestSharp;
using sfcli.Commands;
using sfcli.Dto;
using sfcli.Exceptions;
using sfcli.Services.Abstractions;
using sfcli.SmartfaceClient.Abstractions;

namespace sfcli.Services;

public class RegisterService : IRegisterService, IService
{
    protected readonly IFileSystem _fileSystem;
    private readonly ISmartfaceClient _sfClient;
    private readonly ILogger<RegisterService> _logger;

    public RegisterService(
        IFileSystem fileSystem,
          ISmartfaceClient sfClient,
          ILogger<RegisterService> logger
        )
    {
        _fileSystem = fileSystem;
        _sfClient = sfClient;
        _logger = logger;
    }

    public async Task<RestResponse> RunService(object opts)
    {
        var options = opts as RegisterOptions;
        if (options == null)
        {
            throw new InvalidArgsException("Command line args are null, maybe not parsable");
        }

        CheckOptions(options);
        CheckFilePath(options.PathToFile);

        var dtoMember = new CreateWatchlistMemberRequestDto()
        {
            FullName = options.MemberName,
            DisplayName = options.MemberName
        };

        var response = await _sfClient.CreateWatchlistMemberAsync(dtoMember);
        if (response == null)
        {
            throw new Exception("Unable to create watchlist member");
        }

        if (string.IsNullOrEmpty(response.Id))
        {
            throw new Exception("Watchlist member created incorrectly");
        }

        var dtoRegister = new RegisterMemberRequestDto()
        {
            Id = response.Id,
            Images = new List<Image>() { await LoadFile(options.PathToFile) },
            WatchlistIds = new List<string>() { options.WatchlistId.ToString() },
            FaceDetectorConfig = new FaceDetectorConfig()
        };
        return await _sfClient.RegisterMemberAsync(dtoRegister);
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
    private void CheckOptions(RegisterOptions options)
    {
        if (string.IsNullOrEmpty(options.MemberName))
        {
            throw new InvalidArgsException("MemberName -n missing");
        }

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