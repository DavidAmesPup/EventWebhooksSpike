namespace EventWebHooks.PushEventsToElasticSearch.SubjectHandlers
{
    public interface ISubjectHandler
    {
        bool ShouldHandle(string subject);
        void Handle(string payload);
    }
}