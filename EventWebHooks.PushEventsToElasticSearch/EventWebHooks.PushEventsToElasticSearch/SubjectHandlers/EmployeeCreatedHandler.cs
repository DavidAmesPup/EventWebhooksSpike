using EventWebHooks.PushEventsToElasticSearch.Events;

namespace EventWebHooks.PushEventsToElasticSearch.SubjectHandlers
{
    public class EmployeeCreatedHandler : BaseHandler<EmployeeCreated>, ISubjectHandler
    {
        public override string Subject => "EmployeeCreated";
    }
}