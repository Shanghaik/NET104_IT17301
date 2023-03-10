namespace _3_Asp.Net_MVC.Models
{
    public class Cart
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
