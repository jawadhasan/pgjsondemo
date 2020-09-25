using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

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
