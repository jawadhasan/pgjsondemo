using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace PgdemoApp.DataWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    //enable below code if persistence is required.
                    //services.AddDbContext<AppDbContext>(options =>
                    //{
                    //    options.UseNpgsql("Host=localhost;Database=pgdemoapp;Username=postgres;Password=sasa");
                    //});
                    //services.AddTransient<ILogService, LogService>();
                }).UseWindowsService()
              //.ConfigureLogging((hostContext, logging) => logging.AddEventLog());
              .ConfigureLogging((context, logging) =>
              {
                  logging.AddEventLog(new EventLogSettings()
                  {
                      SourceName = "MyTestSource",
                      LogName = "MyTestLog"
                  });
              });
    }
}
