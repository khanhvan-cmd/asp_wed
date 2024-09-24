﻿using Baitap07.Data;
using Baitap07.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitap07.Controllers
{
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            var theloai = _db.TheLoai.ToList();
            ViewBag.TheLoai = theloai;

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TheLoai theloai)
        {
            if (ModelState.IsValid)

            {

                // Thêm thông tin vào bảng TheLoai
                _db.TheLoai.Add(theloai);
                // Lưu lại
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)

            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult Edit(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.TheLoai.Update(theloai);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.TheLoai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            _db.TheLoai.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }
        [HttpGet]
        public IActionResult Search(string searchString)
        {
            // Nếu có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchString))
            {
                // Sử dụng LINQ để tìm các thể loại có tên chứa từ khóa
                var theloai = _db.TheLoai
                    .Where(tl => tl.Name.Contains(searchString))
                    .ToList();
                ViewBag.searchstring = searchString;
                // Truyền danh sách thể loại tìm được vào ViewBag
                ViewBag.TheLoai = theloai;
            }
            else
            {
                // Nếu không có từ khóa, lấy tất cả các thể loại
                var theloai = _db.TheLoai.ToList();
                ViewBag.TheLoai = theloai;
            }

          
            return View("Index");
        }

    }
}