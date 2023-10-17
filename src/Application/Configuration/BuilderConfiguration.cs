namespace Application.Configuration
{
    public static class BuilderConfiguration
    {
       internal static IConfigurationRoot Builder()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"ocelot.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

                return builder.Build();
        }
    }
}