using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using EventWebHooks.MockEventGenerator.Controllers;
using EventWebHooks.MockEventGenerator.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EventWebHooks.MockEventGenerator.Services
{
    public class EventServices
    {
        private const string TopicArc = "arn:aws:sns:ap-southeast-2:481842150999:EventWebHooksSpike-MySNSTopic-5KQ9CI4KDYQ3";
        private readonly ILogger<MockEventsController> _logger;

        public EventServices(ILogger<MockEventsController> logger)
        {
            _logger = logger;
        }


        public void Publish(ApplicationReceived model)
        {
            var snsclient = new AmazonSimpleNotificationServiceClient();

           var task =  snsclient.PublishAsync(new PublishRequest
            {
                Subject = "ApplicationReceived",
                Message = JsonConvert.SerializeObject(model),
                TopicArn = TopicArc
            });

          var publishResponse =  task.Result;
            _logger.LogInformation($"ApplicationReceived Published {publishResponse.MessageId}. ContentLength: {publishResponse.ContentLength}");

        }

        public void Publish(EmployeeCreated model)
        {
            var snsclient = new AmazonSimpleNotificationServiceClient();

            var task = snsclient.PublishAsync(new PublishRequest
            {
                Subject = "EmployeeCreated",
                Message = JsonConvert.SerializeObject(model),
                TopicArn = TopicArc
            });

            var publishResponse = task.Result;
            _logger.LogInformation($"EmployeeCreated Published {publishResponse.MessageId}. ContentLength: {publishResponse.ContentLength}");

        }
    }
}