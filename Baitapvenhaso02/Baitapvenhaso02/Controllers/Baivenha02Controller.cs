using Microsoft.AspNetCore.Mvc;

namespace Baitapvenhaso02.Controllers
{
    public class Baivenha02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Nguyễn Thị Khánh Vân";
            ViewBag.MSSV = "1822040972";
            ViewData["Nam"] = "Năm 2024";
            return View();
        }
        public IActionResult MayTinh(int a, int b, string pheptinh)
        {
            double PhepTinh;
            if (pheptinh == "cong")
                PhepTinh = a + b;
            else if (pheptinh == "tru")
                PhepTinh = a - b;
            else if (pheptinh == "nhan")
                PhepTinh = a * b;
            else
                PhepTinh = (double)a / b;
            ViewBag.KetQua = PhepTinh;
            return View();
        }
        public IActionResult Profile()
        {
            ViewBag.HoTen = "Nguyễn Thị Khánh Vân";
            ViewBag.MSSV = "1822040972";
            return View();
        }
    }
}
