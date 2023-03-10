namespace _3_Asp.Net_MVC.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int Status { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        

    }
}
