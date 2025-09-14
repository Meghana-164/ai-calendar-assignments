using Microsoft.AspNetCore.Mvc;

namespace AICalendar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        [HttpGet("hello")]
        public ActionResult<string> GetHello()
        {
            return "Hello World!";
        }
    }
}
