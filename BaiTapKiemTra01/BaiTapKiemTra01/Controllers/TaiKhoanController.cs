using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DangKy(TaiKhoanViewModel model)
        {
            if (model.Username != null)
            {
                return Content(model.Username);
            }
            return View();
        }
        public IActionResult DangNhap(SanPhamViewModel model)
        {
            var sanpham = new SanPhamViewModel()
            {
                TenSanPham = "Iced Americano",
                GiaBan = 15000000, // 15 million VND
                AnhMoTa  = "img/iced-americano.png"
            };
           
            return View(sanpham);
        }

    }
}