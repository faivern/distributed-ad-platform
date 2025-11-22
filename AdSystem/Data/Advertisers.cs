using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdSystem.Data
{
    [Table("tbl_annonsorer")]
    public class Advertisers
    {
        [Required]
        [Key]
        [Column("adv_id")]
        public int? AdvSubscriberId { get; set; }

        [Column("adv_type")]
        public string AdvType { get; set; } = null!;

        [Column("adv_first_name")]
        public string AdvFirstName { get; set; } = null!;

        [Column("adv_last_name")]
        public string AdvLastName { get; set; } = null!;

        [Column("adv_org_number")]
        public string? AdvOrgNumber { get; set; } = null!;

        [Column("adv_address")]
        public string AdvAddress { get; set; } = null!;

        [Column("adv_phone")]
        public string AdvPhone { get; set; } = null!;

        [Column("adv_zip_code")]
        public string AdvZipCode { get; set; } = null!;

        [Column("adv_city")]
        public string AdvCity { get; set; } = null!;

        [Column("adv_invoice_address")]
        public string? AdvInvoiceAddress { get; set; } = null!;

        [Column("adv_invoice_zip_code")]
        public string? AdvInvoiceZipCode { get; set; } = null!;

        [Column("adv_invoice_city")]
        public string? AdvInvoiceCity { get; set; } = null!;



    }
}
