using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using Amazon.Lambda.SNSEvents;
using EventWebHooks.PushEventsToElasticSearch.SubjectHandlers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.

[assembly: LambdaSerializer(typeof(JsonSerializer))]

namespace EventWebHooks.PushEventsToElasticSearch
{
    public class Function
    {
        private readonly IEnumerable<ISubjectHandler> _handlers = new List<ISubjectHandler>
        {
            new ApplicationReceivedHandler(),
            new EmployeeCreatedHandler()
        };

        public string Handler(SNSEvent snsEvent)
        {
            Console.WriteLine($"Function starting at {DateTime.Now}");
            foreach (var record in snsEvent.Records)
            {
                var snsRecord = record.Sns;

                Console.WriteLine($"Handling Message with subject {snsRecord.Subject} and timestamp {snsRecord.Timestamp} ");

                _handlers.First(h => h.ShouldHandle(snsRecord.Subject)).Handle(snsRecord.Message);

                Console.WriteLine($"Handled message successfully!");
            }

            return $"Finished at {DateTime.Now}";
        }
    }
}