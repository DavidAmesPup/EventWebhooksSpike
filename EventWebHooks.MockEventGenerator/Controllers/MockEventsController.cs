using EventWebHooks.MockEventGenerator.Models;
using EventWebHooks.MockEventGenerator.Services;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventWebHooks.MockEventGenerator.Controllers
{
    [Route("api/[controller]")]
    public class MockEventsController : Controller
    {
        private readonly EventServices _eventServices;
        private readonly ILogger _logger;

        public MockEventsController(ILogger<MockEventsController> logger,
                                    EventServices eventServices)
        {
            _logger = logger;
            _eventServices = eventServices;
        }


        [HttpGet("/CreateRandomApplicationReceived")]
        public IActionResult CreateRandomApplicationReceived()
        {
            var applicationReceived = new ApplicationReceived
            {
                EmailAddres = Internet.Email(),
                FirstName = Name.First(),
                LastName = Name.Last(),
                Company = Company.Name(),
                Position = Company.CatchPhrase()
            };

            _logger.LogInformation("Received event on employee created");

            return PostApplicationReceived(applicationReceived);
        }


        [HttpGet("/CreateRandomEmployeeCreated")]
        public IActionResult CreateRandomEmployeeCreated()
        {
            var employeeCreated = new EmployeeCreated
            {
                EmailAddres = Internet.Email(),
                FirstName = Name.First(),
                LastName = Name.Last()
            };

            _logger.LogInformation("Received event on employee created");

            return PostEmployeeCreated(employeeCreated);
        }


        [HttpPost("/EmployeeCreated")]
        public IActionResult PostEmployeeCreated([FromBody] EmployeeCreated eventModel)
        {
            _logger.LogInformation("Received event on employee created");

            return Ok();
        }

        [HttpPost("/ApplicationReceived")]
        public IActionResult PostApplicationReceived([FromBody] ApplicationReceived eventModel)
        {
            _logger.LogInformation("Received event on application received created");

            return Ok();
        }
    }
}