namespace _3_Asp.Net_MVC.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Role> Roles { get; set;}
        public virtual Bill? Bill { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
