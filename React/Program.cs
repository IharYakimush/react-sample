using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace React
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                }).Build().Run();
        }
    }
}
