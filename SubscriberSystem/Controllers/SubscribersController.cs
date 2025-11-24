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

        // GET api/subscribers/{subscriberId}
        [HttpGet("{subscriberId:int}")]
        public ActionResult<Subscriber> GetSubscriberById(int subscriberId)
        {
            var subscriber = _subscriberService.GetSubscriberById(subscriberId);
            if (subscriber == null)
            {
                return NotFound();
            }
            return Ok(subscriber);
        }

    }
}
