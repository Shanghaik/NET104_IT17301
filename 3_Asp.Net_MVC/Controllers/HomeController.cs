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
            var x = HttpContext.Session.GetString("ThongBao"); // Lấy từ Session
            ViewData["Session"] = x;
            return View(); // Thực hiện tới View có cùng tên với Action
        }
        public IActionResult Test()
        {
            //Product pd = new Product();
            //pd.Name = "Crispy Snack";
            //pd.Supplier = "Oishii de tsu ne";
            //pd.Description = "Delicious";
            //pd.AvailableQuantity = 33;
            //pd.Status = 1;
            return RedirectToAction("MultipleData"); // Thực hiện truyền 1 đối tượng vào một View nào đó
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

        public IActionResult Details(Guid id)
        {
            Product product = productServices.GetProductById(id);
            return View(product);
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

        public IActionResult MultipleData()
        {
            // Thực hiện truyền dữ liệu sang View mà không bị giới hạn 
            // Các cách
            // 1. Sử dụng ViewData - cơ chế Key value
            List<string> strings = new List<string>() { "ABC", "XYZ", "MNP" };
            ViewData["NameList"] = strings; // Tạo 1 Viewdata chứa thông tin của List
            // 2. Sử dụng ViewBag 
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            ViewBag.Number = arr; // Tự đặt tên Number 
            // Lưu ý: ViewData chỉ có thể gán 1 kiểu dữ liệu còn ViewBag thì nhiều
            // ViewData là Dictionary còn ViewBag là dynamic type object
            // Tốc độ truy xuất dữ liệu thì ViewData nhanh hown ViewBag
            // 3. Sử dụng Tempdata
            string message = "Đói quá";
            // 4. Sử dụng Session 
            HttpContext.Session.SetString("ThongBao", message); // Lưu vào Session
            TempData["Message"] = message;
            var x = HttpContext.Session.GetString("ThongBao"); // Lấy từ Session
            ViewData["Session"] = x;
            return View();
        }
        public IActionResult TestViewBag()
        {
            // ViewBag và ViewData chỉ có thể sử dụng trong 1 Action cụ thể mà
            // nó được khai báo
            var x = HttpContext.Session.GetString("ThongBao"); // Lấy từ Session
            ViewData["Session"] = x;
            return View();
        }

        public IActionResult AddToCart(Guid id)
        {
            // Code
            // Từ Id lấy được của Sản phẩm ta lấy ra sản phẩm đó
            var product = productServices.GetProductById(id);
            // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");
            if (products.Count == 0)
            {
                products.Add(product); // Nếu Cart rỗng thì thêm sp vào luôn
                // Đưa dữ liệu về lại Session
                SessionServices.SetObjToJson(HttpContext.Session, "Cart", products);
            }
            else
            {
                if (!SessionServices.CheckProductInCart(id, products)) // SP chưa nằm trong cart
                {
                    products.Add(product); // Nếu Cart chưa chứa sản phẩm thì thêm sp vào luôn
                                           // Đưa dữ liệu về lại Session
                    SessionServices.SetObjToJson(HttpContext.Session, "Cart", products);
                }
                else return Content("Sản phẩm đã nằm trong giỏ");
            }
            // Lấy từ Session
            return RedirectToAction("ShowCart");
        }
        public IActionResult ShowCart()
        {
            // Đọc dữ liệu từ Session và truyền vào View
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}