namespace sfcli;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddAppConfiguration(this IConfigurationBuilder builder, IHostEnvironment environment)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        if (environment == null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        // get the base directory
        var settingsDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // add appsettings.json configuration
        builder
            .AddJsonFile(Path.Combine(settingsDirectory, "appsettings.json"));

        return builder;
    }
}
