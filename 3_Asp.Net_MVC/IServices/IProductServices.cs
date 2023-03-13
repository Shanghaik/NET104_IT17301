using _3_Asp.Net_MVC.Models;

namespace _3_Asp.Net_MVC.IServices
{
    public interface IProductServices
    {
        // Các phương thức lấy ra sản phẩm
        public List<Product> GetAllProduct();
        public Product GetProductById(Guid id);
        public List<Product> GetProductByName(string name);
        // Phương thức Thêm
        public bool CreateProduct(Product p);
        // Phương thức Sửa
        public bool UpdateProduct(Product p); 
        // Phương thức xóa
        public bool DeleteProduct(Guid id);

    }
}
