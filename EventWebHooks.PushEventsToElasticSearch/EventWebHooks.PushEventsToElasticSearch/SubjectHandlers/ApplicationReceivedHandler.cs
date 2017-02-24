using EventWebHooks.PushEventsToElasticSearch.Events;

namespace EventWebHooks.PushEventsToElasticSearch.SubjectHandlers
{
    public class ApplicationReceivedHandler : BaseHandler<ApplicationReceived>, ISubjectHandler
    {
        public override string Subject => "ApplicationReceived";
    }
}