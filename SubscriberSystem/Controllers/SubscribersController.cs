using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubscriberSystem.Data;
using SubscriberSystem.Services;

namespace SubscriberSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
       private readonly ISubscriberService _subscriberService;

        public SubscribersController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        // GET api/subscribers/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Subscriber> GetSubscriberById(int id)
        {
            var subscriber = _subscriberService.GetSubscriberById(id);
            if (subscriber == null)
            {
                return NotFound();
            }
            return Ok(subscriber);
        }

    }
}
