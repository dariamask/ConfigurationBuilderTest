using Microsoft.Extensions.Configuration;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddDirectoryAsConfig(this IConfigurationBuilder builder, string directoryPath)
    {
        var data = new Dictionary<string, string>();
        ProcessDirectory(directoryPath, data, "");

        builder.AddInMemoryCollection(data);
        return builder;
    }

    private static void ProcessDirectory(string path, IDictionary<string, string> data, string parentKey)
    {
        var directoryInfo = new DirectoryInfo(path);
        foreach (var file in directoryInfo.GetFiles())
        {
            var key = $"{parentKey}{Path.GetFileNameWithoutExtension(file.Name)}";
            var value = File.ReadAllText(file.FullName);
            data[key] = value;
        }

        foreach (var directory in directoryInfo.GetDirectories())
        {
            var key = $"{parentKey}{directory.Name}:";
            ProcessDirectory(directory.FullName, data, key);
        }
    }
}