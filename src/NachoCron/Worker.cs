using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NachoCron.Quartz;

namespace NachoCron
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly SchedulerFactory _schedulerFactory;

        public Worker(ILogger<Worker> logger, SchedulerFactory schedulerFactory)
        {
            _logger = logger;
            _schedulerFactory = schedulerFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(Resources.ServiceStarting);

            var scheduler = await _schedulerFactory.GetSchedulerAsync();

            await scheduler.Start(CancellationToken.None);

            await Task.Delay(Timeout.Infinite, stoppingToken);

            _logger.LogInformation(Resources.ServiceStopping);

            await scheduler.Shutdown(CancellationToken.None);

            _logger.LogInformation(Resources.ServiceStopped);
        }
    }
}
