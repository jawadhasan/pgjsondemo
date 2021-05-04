using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using LicenseHelper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PgdemoApp.DataWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var configFilePath = Path.Combine(basePath, "SWSConfig.xml");
            var configFileLoader = new ConfigFileLoader(configFilePath);

            var configData = configFileLoader.GetConfigData();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogInformation("InstallDate: {0} ", configData.InstallDate);
                _logger.LogInformation("JulianDate: {0}", configData.FromJulianDate);
             


                //InsertRecord();

                await Task.Delay(10000, stoppingToken);
            }
        }

        private void InsertRecord()
        {
            //persistence

            // var logInfo = new LogRecord() { LogInfo = "PgdemoApp.DataWorker executed" };

            //https://stackoverflow.com/questions/62066501/dependency-injection-in-asp-net-core-worker-service
            //using (var scope = _serviceProvider.CreateScope())
            //{
            //   await scope.ServiceProvider.GetRequiredService<ILogService>().InsertRecord(logInfo);
            //}
        }
    }
}
