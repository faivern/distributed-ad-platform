using SubscriberSystem.Data;
namespace SubscriberSystem.Services
// interface added for architecture and industry best practices, not specifically for the functionality of the code for this assignment.
{
    public interface ISubscriberService
    {
        Subscriber? GetSubscriberById(int id);
    }
}
