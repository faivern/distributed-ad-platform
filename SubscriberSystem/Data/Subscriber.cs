using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubscriberSystem.Data
{
    [Table("tbl_subscribers")]
    public class Subscriber
    {
        [Key]
        [Column("sub_subscriber_id")]
        public int SubscriberId { get; set; }

        [Required]
        [Column("sub_social_security")]
        [StringLength(13)]
        public string SocialSecurity { get; set; } = null!;

        [Required]
        [Column("sub_first_name")]
        [StringLength(80)]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column("sub_last_name")]
        [StringLength(80)]
        public string LastName { get; set; } = null!;

        [Required]
        [Column("sub_delivery_address")]
        [StringLength(120)]
        public string DeliveryAddress { get; set; } = null!;

        [Required]
        [Column("sub_zip_code")]
        [StringLength(16)]
        public string ZipCode { get; set; } = null!;

        [Required]
        [Column("sub_phone")]
        [StringLength(50)]
        public string Phone { get; set; } = null!;

        [Required]
        [Column("sub_city")]
        [StringLength(200)]
        public string City { get; set; } = null!;
    }
}
