using _3_Asp.Net_MVC.IServices;
using _3_Asp.Net_MVC.Models;

namespace _3_Asp.Net_MVC.Services
{
    public class ProductServices : IProductServices
    {
        ShoppingDbContext context;
        public ProductServices(){
            context = new ShoppingDbContext();
        }
        public bool CreateProduct(Product p)
        {
            try
            {
                context.Products.Add(p); 
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }     
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProduct()
        {
            return context.Products.ToList();// Lấy tất cả các sản phẩm
        }

        public Product GetProductById(Guid id)
        {
            return context.Products.FirstOrDefault(p => p.ID == id);
            // return context.Products.SingleOrDefault(p => p.ID == id);
        }

        public List<Product> GetProductByName(string name)
        {
            return context.Products.Where(p=>p.Name.Contains(name)).ToList();
            // Trả về danh sách những Sản phẩm mà tên có chứa chuỗi cần tìm
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                var product = context.Products.Find(p.ID);
                product.Name = p.Name;
                product.Description = p.Description;    
                product.Price = p.Price;
                product.Supplier = p.Supplier;
                product.Status = p.Status;
                product.AvailableQuantity= p.AvailableQuantity;
                context.SaveChanges(); return true; 
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
