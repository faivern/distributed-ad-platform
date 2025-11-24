using AdSystem.Data;
using System.ComponentModel.DataAnnotations;

namespace AdSystem.Models
{
    public class AdFormViewModel
    {

        // Who is placing the ad
        public bool IsCompany { get; set; }          // chosen via radio button

      //  [Required(ErrorMessage = "Giltigt prenumerationsnummer krävs")]
        public int? SubscriberId { get; set; }

        // Shared contact info
        [Required(ErrorMessage = "Förnamn krävs")]
        [StringLength(50, ErrorMessage = "Förnamn får vara max 50 tecken långt")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Efternamn krävs")]
        [StringLength(50, ErrorMessage = "Efternamn får vara max 50 tecken långt")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Personnummer krävs")]
        [RegularExpression(@"^\d{8}-\d{4}$", ErrorMessage = "Personnummer måste vara i formatet ÅÅÅÅMMDD-XXXX")]
        public string SocialSecurity { get; set; } = null!;

        [Required(ErrorMessage = "Telefonnummer krävs")]
        [Phone(ErrorMessage = "Ogiltigt telefonnummer")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Leveransadress krävs")]
        [StringLength(100, ErrorMessage = "Leveransadress får vara max 100 tecken långt")]
        public string DeliveryAddress { get; set; } = null!;

        [Required(ErrorMessage = "Postnummer krävs")]
        [RegularExpression(@"^\d{3}-?\d{2}$", ErrorMessage = "Postnummer måste vara i formatet 65591 eller 655-91")]
        public string ZipCode { get; set; } = null!;

        [Required(ErrorMessage = "Ort krävs")]
        [StringLength(50, ErrorMessage = "Ort får vara max 50 tecken långt")]
        public string City { get; set; } = null!;



        // Company-only fields
      [Required(ErrorMessage = "Orgnummer krävs")]
      [StringLength(20, ErrorMessage = "Orgnummer får vara max 20 tecken långt")]
        public string? OrgNumber { get; set; }
       // [Required(ErrorMessage = "Fakturaadress krävs")]
       // [StringLength(100, ErrorMessage = "Fakturaadress får vara max 100 tecken långt")]
        public string? InvoiceAddress { get; set; }
       // [Required(ErrorMessage = "Fakturaadress krävs")]
       // [StringLength(100, ErrorMessage = "Fakturaadress får vara max 100 tecken långt")]
        public string? InvoiceZipCode { get; set; }
       // [Required(ErrorMessage = "Fakturapostnummer krävs")]
       // [RegularExpression(@"^\d{3}-?\d{2}$", ErrorMessage = "Fakturapostnummer måste vara i formatet 65591 eller 655-91")]
        public string? InvoiceCity { get; set; }



        // Ad fields
        [Required(ErrorMessage = "Rubrik krävs")]
        [StringLength(100, ErrorMessage = "Rubrik får vara max 100 tecken långt")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Beskrivning krävs")]
        [StringLength(1000, ErrorMessage = "Beskrivning får vara max 1000 tecken långt")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Pris krävs")]
        [Range(0.01, 100000000.00, ErrorMessage = "Pris måste vara mellan 0.01 och 100,000,000.00")]
        public decimal ItemPrice { get; set; }

        // automatic values
        public decimal AdPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // ViewModel for displaying ads with currency selection
    public class AdsIndexViewModel
    {
        public List<Ads> Ads { get; set; } = new();
        public string SelectedCurrency { get; set; } = "SEK";
        public List<string> AvailableCurrencies { get; set; } = new() { 
            "SEK", 
            "EUR", 
            "USD", 
            "GBP", 
            "CHF", 
            "NOK",
            "DKK",
            "JPY",
            "AUD",
            "CAD",
            "RUB",
        };
        public decimal CurrentRate { get; set; } = 1m;  // SEK DEFAULT
    }

}