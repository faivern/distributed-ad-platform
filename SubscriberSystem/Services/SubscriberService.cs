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

        public IEnumerable<Subscriber> GetAllSubscribers()
        {
            return _context.Subscribers.ToList();
        }

        public Subscriber? GetSubscriberById(int id)
        {
            return _context.Subscribers.Find(id);
        }

        public Subscriber CreateSubscriber(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
            _context.SaveChanges();
            return subscriber;
        }

        public Subscriber? UpdateSubscriber(int id, Subscriber subscriber)
        {
            var existing = _context.Subscribers.Find(id);
            if (existing == null)
                return null;

            // Update fields
            existing.FirstName = subscriber.FirstName;
            existing.LastName = subscriber.LastName;
            existing.DeliveryAddress = subscriber.DeliveryAddress;
            existing.Phone = subscriber.Phone;
            existing.ZipCode = subscriber.ZipCode;
            existing.City = subscriber.City;
            existing.SocialSecurity = subscriber.SocialSecurity;

            _context.SaveChanges();
            return existing;
        }

        public bool DeleteSubscriber(int id)
        {
            var existing = _context.Subscribers.Find(id);
            if (existing == null)
                return false;

            _context.Subscribers.Remove(existing);
            _context.SaveChanges();
            return true;
        }
    }
}
