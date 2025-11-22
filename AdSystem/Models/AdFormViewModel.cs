namespace AdSystem.Models
{
    public class AdFormViewModel
    {
        // Who is placing the ad
        public bool IsCompany { get; set; }          // chosen via radio button
        public int? SubscriberId { get; set; }

        // Shared contact info
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string SocialSecurity { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;

        // Company-only fields
        public string? OrgNumber { get; set; }
        public string? InvoiceAddress { get; set; }
        public string? InvoiceZipCode { get; set; }
        public string? InvoiceCity { get; set; }

        // Ad fields
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal ItemPrice { get; set; }

        // automatic values
        public decimal AdPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}