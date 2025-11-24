namespace AdSystem.Models
{
    public class SubscriberUpdateDto
    {
        public int SubscriberId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SocialSecurity { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
    }
}
