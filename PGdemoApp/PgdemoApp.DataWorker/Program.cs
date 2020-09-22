using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
