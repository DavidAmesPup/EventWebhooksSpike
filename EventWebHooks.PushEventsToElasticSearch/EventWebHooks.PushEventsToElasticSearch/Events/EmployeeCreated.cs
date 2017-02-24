namespace EventWebHooks.PushEventsToElasticSearch.Events
{
    public class EmployeeCreated
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddres { get; set; }

        public override string ToString() => $"EmployeeCreated {FirstName} {LastName}";

    }
}
