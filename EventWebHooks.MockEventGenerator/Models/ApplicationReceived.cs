using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventWebHooks.MockEventGenerator.Models
{
    public class ApplicationReceived
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string EmailAddres { get; set; }
        public string Position { get; set; }
    }
}
