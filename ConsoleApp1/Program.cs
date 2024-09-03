using Microsoft.Extensions.Configuration;

public class Program
{
    public static void Main()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddDirectoryAsConfig("C:\\Repos\\myconfig");
        var configuration = configurationBuilder.Build();

        Console.WriteLine($"Branch#1 file#1: {configuration["branch1:file1"]}");
        Console.WriteLine($"Branch#2 file#1: {configuration["branch2:file2"]}");
        Console.WriteLine($"Branch#2 file#3: {configuration["branch2:file3"]}");
    }
}