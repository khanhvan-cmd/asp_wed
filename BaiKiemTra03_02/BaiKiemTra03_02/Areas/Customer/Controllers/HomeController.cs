using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaiKiemTra03_02.Models; // Assuming your models are in this namespace
using System.Collections.Generic;
using BaiKiemTra03_02.Data;

namespace BaiKiemTra03_02.Areas.Customers.Controllers
{
    [Area("Customers")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Action to display a list of SanPham
        public IActionResult Index()
        {
            IEnumerable<Book> sanpham = _db.Books.Include(sp => sp.Author).ToList();
            return View(sanpham);
        }

        // Action to display details of a specific SanPham
        public IActionResult Details(int id)
        {
            Book Books = _db.    Books.Include(sp => sp.Author)
                .FirstOrDefault(sp => sp.BookId == id);

            if (Books == null)
            {
                return NotFound();
            }

            return View(Books);
        }

        // Other actions
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
