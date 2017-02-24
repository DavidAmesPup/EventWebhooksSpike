using System;
using Elasticsearch.Net;
using Elasticsearch.Net.Aws;
using Nest;
using Newtonsoft.Json;

namespace EventWebHooks.PushEventsToElasticSearch.SubjectHandlers
{
    public abstract class BaseHandler<TEvent> where TEvent : class
    {
        public abstract string Subject { get; }
        
        public bool ShouldHandle(string subject)
        {
            return subject == Subject;
        }

        public void Handle(string payload)
        {
            var indexName = "events";

            var eventModel = JsonConvert.DeserializeObject<TEvent>(payload);
            Console.WriteLine($"Handling {Subject} for {eventModel}");

            var httpConnection = new AwsHttpConnection("ap-southeast-2");

            var pool = new SingleNodeConnectionPool(new Uri("https://search-event-web-hooks-spike-ps5wglqfqvdjqwtijvvvtmvmte.ap-southeast-2.es.amazonaws.com/"));
            var config = new ConnectionSettings(pool, httpConnection);
            var client = new ElasticClient(config);
           var response = client.Index(eventModel, p => p.Index(indexName).Refresh(Refresh.True));

            if (response.IsValid)
                Console.WriteLine($"Successfully sent {eventModel} to elastic search.");
            else


            Console.WriteLine($"FAILED to send {eventModel} to elastic search. {response.DebugInformation}");
        }
    }
}