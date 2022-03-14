using System.IO.Abstractions;

using CommandLine;

using sfcli;
using sfcli.Commands;
using sfcli.Services;
using sfcli.Services.Abstractions;
using sfcli.SmartfaceClient;
using sfcli.SmartfaceClient.Abstractions;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<ISmartfaceClient, SmartfaceClient>();
        
        services.AddSingleton<ICreateWatchlistService, CreateWatchlistService>();
        services.AddSingleton<IGetService, GetService>();
        services.AddSingleton<IRegisterService, RegisterService>();
        services.AddSingleton<ISearchService, SearchService>();
        
        services.AddSingleton<IFileSystem, FileSystem>();
    })
    .ConfigureAppConfiguration((host, configure) =>
    {
        configure.AddAppConfiguration(host.HostingEnvironment);
    }).Build();

return await Parser.Default.ParseArguments<CreateOptions, GetOptions, RegisterOptions, SearchOptions>(args)
    .MapResult(
        async (CreateOptions opts) => await RunService<ICreateWatchlistService>(opts),
        async (GetOptions opts) => await RunService<IGetService>(opts),
        async (RegisterOptions opts) => await RunService<IRegisterService>(opts),
        async (SearchOptions opts) => await RunService<ISearchService>(opts),
        async errs => await Task.FromResult(1)
    );

async Task<int> RunService<T>(object opts) where T : IService
{
    var logger = host.Services.GetService<ILogger<Program>>();
    try
    {
        var service = host.Services.GetRequiredService<T>();    
        var result = await service.RunService(opts);

        logger?.LogInformation("Response HttpStatus: - {0}\nResponse Content: - {1}", 
            result.StatusCode.ToString(),
            result.Content);

        return 0;
    }
    catch (System.Exception ex)
    {
        logger?.LogError(ex.ToString());
        return 1;
    }
}