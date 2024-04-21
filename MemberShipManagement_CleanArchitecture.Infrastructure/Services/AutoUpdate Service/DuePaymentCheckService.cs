using MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Services.AutoUpdate_Service
{
    public class DuePaymentCheckService : IHostedService, IDisposable
    {
        private Timer? _timer;
        private readonly IServiceScopeFactory _scopeFactory;

        public DuePaymentCheckService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            
            TimeSpan delay = CalculateDelayUntilNextExecution();

            _timer = new Timer(DoWork, null, delay, TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private TimeSpan CalculateDelayUntilNextExecution()
        {
            DateTime now = DateTime.Now;
            DateTime nextExecutionTime = now.Date.AddDays(1).AddMinutes(1);

            TimeSpan delay = nextExecutionTime - now;
            return delay;
        }


        private async void DoWork(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var duePaymentService = scope.ServiceProvider.GetRequiredService<IDuePaymentRepository>();

                var currentDate = DateTime.Now;
                var dayOfMonth = currentDate.Day;

                if (dayOfMonth <= 10)
                {
                    if (dayOfMonth == 11)
                    {
                        await duePaymentService.HandleDuePayments();
                    }
                }
                else
                {
                    await duePaymentService.HandleDuePayments();
                }
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
