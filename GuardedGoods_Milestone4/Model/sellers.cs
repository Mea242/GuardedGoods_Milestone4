using System.ComponentModel.DataAnnotations;

namespace GuardedGoods_Milestone4.Model
{
    public class sellers
    {
        [Key]
        public string seller_ID { get; set; } = string.Empty;
        public string user_ID { get; set; } = string.Empty;
        public int average_rating { get; set; }
        public bool verification_status { get; set; }
    }
}
