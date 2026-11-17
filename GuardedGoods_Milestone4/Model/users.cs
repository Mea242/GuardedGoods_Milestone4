using System.ComponentModel.DataAnnotations;

namespace GuardedGoods_Milestone4.Model
{
    public class users
    {
        [Key]
        public string userID { get; set; } = string.Empty;
        public string full_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string validationID { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool? status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime last_login { get; set; }
    }
}
