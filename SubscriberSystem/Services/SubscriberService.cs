using SubscriberSystem.Data;

namespace SubscriberSystem.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly SubscriberDbContext _context;

        public SubscriberService(SubscriberDbContext context)
        {
            _context = context;
        }

        public Subscriber? GetSubscriberById(int id)
        {
            return _context.Subscribers.Find(id);
        }
    }
}
