using System.Configuration;


namespace APBD_EX03;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] strings) =>
        Host.CreateDefaultBuilder(strings).ConfigureWebHostDefaults(webBuilder => {webBuilder.UseStartup<Start>();});
}


