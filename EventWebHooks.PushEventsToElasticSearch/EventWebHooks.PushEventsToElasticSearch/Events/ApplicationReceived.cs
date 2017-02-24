namespace EventWebHooks.PushEventsToElasticSearch.Events
{
    public class ApplicationReceived
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string EmailAddres { get; set; }
        public string Position { get; set; }

        public override string ToString() => $"ApplicationReceived {FirstName} {LastName}";

    }
}
