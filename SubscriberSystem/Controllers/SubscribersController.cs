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

        // GET api/subscribers
        [HttpGet]
        public ActionResult<IEnumerable<Subscriber>> GetAllSubscribers()
        {
            return Ok(_subscriberService.GetAllSubscribers());
        }

        // GET api/subscribers/{id}
        [HttpGet("{subscriberId:int}")]
        public ActionResult<Subscriber> GetSubscriberById(int subscriberId)
        {
            var subscriber = _subscriberService.GetSubscriberById(subscriberId);
            if (subscriber == null)
                return NotFound();

            return Ok(subscriber);
        }

        // POST api/subscribers
        [HttpPost]
        public ActionResult<Subscriber> CreateSubscriber([FromBody] Subscriber subscriber)
        {
            var created = _subscriberService.CreateSubscriber(subscriber);
            return CreatedAtAction(nameof(GetSubscriberById), new { subscriberId = created.SubscriberId }, created);
        }

        // PUT api/subscribers/{id}
        [HttpPut("{subscriberId:int}")]
        public ActionResult<Subscriber> UpdateSubscriber(int subscriberId, [FromBody] Subscriber subscriber)
        {
            var updated = _subscriberService.UpdateSubscriber(subscriberId, subscriber);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE api/subscribers/{id}
        [HttpDelete("{subscriberId:int}")]
        public ActionResult DeleteSubscriber(int subscriberId)
        {
            var deleted = _subscriberService.DeleteSubscriber(subscriberId);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
