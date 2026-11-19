using System.ComponentModel.DataAnnotations;

namespace GuardedGoods_Milestone4.Model
{
    public class cart
    {
        public string user_ID { get; set; } = string.Empty;
        public string product_ID { get; set; } = string.Empty;

        [Key]
        public string cart_ID { get; set; } = string.Empty;

        public int? quantity { get; set; }
        public decimal? cart_total { get; set; }
    }
}
