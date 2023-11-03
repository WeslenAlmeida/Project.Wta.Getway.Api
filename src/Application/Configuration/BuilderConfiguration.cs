namespace Application.Configuration
{
    public static class BuilderConfiguration
    {
       internal static IConfigurationRoot Builder()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"ocelot.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();

                return builder.Build();
        }
    }
}