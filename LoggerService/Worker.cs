using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Core.CallBacks;
using JsonCallBacks.JsonNotification;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SocketIOClient;

namespace LoggerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var callBacks = new List<Notifier<string>>() {new SystemPropertiesNotification(properties =>
            {
                _logger.LogInformation(properties.OS);
            })};
            
            var sc = new SocketIO("http://localhost:5000", new SocketIOOptions() {EIO = 4});

            foreach (var callBack in callBacks)
            {
                sc.On(callBack.Identifier,response => callBack.CallBack(response.GetValue().GetRawText()));
            }
            
            await sc.ConnectAsync();
        }
    }
}