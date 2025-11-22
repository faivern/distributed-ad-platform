using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdSystem.Data
{
    [Table("tbl_ads")]
    public class Ads
    {
        [Key]
        [Column("ad_id")]
        public int AdId { get; set; }

        [Column("ad_title")]
        public string AdTitle { get; set; } = null!;

        [Column("ad_description")]
        public string AdDescription { get; set; } = null!;

        [Column("ad_item_price")]
        public decimal AdItemPrice { get; set; }

        [Column("ad_advertising_price")]
        public decimal AdAdvertisingPrice { get; set; }

        [Column("ad_created_at")]
        public DateTime AdCreatedAt { get; set; }

        //FK adv_id
        [Column("adv_id")]
        public int AdvId { get; set; }

    }
}
