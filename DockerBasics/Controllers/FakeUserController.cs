using Microsoft.AspNetCore.Mvc;
using Bogus;


namespace DockerBasics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FakeUserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<FakeUserController> _logger;

        public FakeUserController(ILogger<FakeUserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Users")]
        public IActionResult Get()
        {

            var fakeUser = new Faker<UserDto>()
                .RuleFor(x => x.Id, f => Guid.NewGuid())
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.Email,f => f.Internet.Email())
                ;

            var user = fakeUser.Generate();
            return Ok(user);

        }
    }
}