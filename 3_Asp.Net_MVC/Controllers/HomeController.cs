using _3_Asp.Net_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _3_Asp.Net_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            var products = new List<Product>() {
                new Product{ID = Guid.NewGuid(), Name = "Thịt gà", Price = 1000, AvailableQuantity = 15,
                Status = 1,Supplier = "KhanhPG", Description = "Ngon" },
                new Product{ID = Guid.NewGuid(), Name = "Thịt bò", Price = 2000, AvailableQuantity = 14,
                Status = 1,Supplier = "DungNA29", Description = "Rất Ngon" },
                new Product{ID = Guid.NewGuid(), Name = "Thịt lợn", Price = 900, AvailableQuantity = 12,
                Status = 1,Supplier = "TienNH21", Description = "Hơi Ngon" }
            };

            return View("Product", products); // Trả về 1 View Cụ thể đi kèm với Model
        }

        public IActionResult Edit() // Chỉ thực hiện việc hiển thị ra form Edit
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(Guid id) // Thực hiện việc Sửa
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}