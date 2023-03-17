using _3_Asp.Net_MVC.IServices;
using _3_Asp.Net_MVC.Models;
using _3_Asp.Net_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _3_Asp.Net_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices productServices; // Interface 
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productServices = new ProductServices();    // new Class
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View(); // Thực hiện tới View có cùng tên với Action
        }
        public IActionResult Test()
        {
            Product pd = new Product();
            pd.Name = "Crispy Snack";
            pd.Supplier = "Oishii de tsu ne";
            pd.Description = "Delicious";
            pd.AvailableQuantity = 33;
            pd.Status = 1;
            return View(pd); // Thực hiện truyền 1 đối tượng vào một View nào đó
        }

        public IActionResult Redirect()
        {
            // List fake
            //var products = new List<Product>() {
            //    new Product{ID = Guid.NewGuid(), Name = "Thịt gà", Price = 1000, AvailableQuantity = 15,
            //    Status = 1,Supplier = "KhanhPG", Description = "Ngon" },
            //    new Product{ID = Guid.NewGuid(), Name = "Thịt bò", Price = 2000, AvailableQuantity = 14,
            //    Status = 1,Supplier = "DungNA29", Description = "Rất Ngon" },
            //    new Product{ID = Guid.NewGuid(), Name = "Thịt lợn", Price = 900, AvailableQuantity = 12,
            //    Status = 1,Supplier = "TienNH21", Description = "Hơi Ngon" }
            //};
            List<Product> products = productServices.GetAllProduct();
            return View("Product", products); // Trả về 1 View Cụ thể đi kèm với Model
        }

        public IActionResult Edit(Product product) // Sửa
        {
            if (productServices.UpdateProduct(product))
            {
                return RedirectToAction("Redirect");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(Guid id) // CHỉ hiển thị
        {
            Product product = productServices.GetProductById(id);
            return View(product);
        }

        public IActionResult Details()
        {

            return View();
        }
        public IActionResult Create() // Hiển thị View
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product) // Thực hiện chức năng thêm
        {
            if (productServices.CreateProduct(product)) // Nếu thêm thành công
            {
                return RedirectToAction("Redirect");
            }
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            if (productServices.DeleteProduct(id))
            {
                return RedirectToAction("Redirect");
            }
            else return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}