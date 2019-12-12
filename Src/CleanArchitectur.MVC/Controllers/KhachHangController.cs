using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectur.MVC.Controllers
{
    public class KhachHangController : Controller
    {
        private IKhachHangS ikhachhangs;
        public KhachHangController(IKhachHangS ikhachhangs)
        {
            this.ikhachhangs = ikhachhangs;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("VaiTro") != "NguoiQuanTri" && HttpContext.Session.GetString("VaiTro") != "NhanVien")
            {
                return Redirect(@"~/NguoiDung/Login");
            }
            else
            {
                ViewBag.Name = HttpContext.Session.GetString("Ten");
                return View(ikhachhangs.GetKhachHangs());
            }
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Name = HttpContext.Session.GetString("Ten");
            return View();
        }

        [HttpPost]
        public IActionResult Create(KhachHangViewModel save)
        {
            if (ModelState.IsValid)
            {
                save.Id = 0;
                ikhachhangs.Create(save);
                return RedirectToAction("Index");
            }
            return View(save);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.Name = HttpContext.Session.GetString("Ten");
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            ikhachhangs.remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.Name = HttpContext.Session.GetString("Ten");
                var kh = ikhachhangs.GetKhachHang(Id);
                return View(kh);
            }
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditConfirm(KhachHangViewModel save)
        {
            if (ModelState.IsValid)
            {
                ikhachhangs.Create(save);
                return RedirectToAction("Index");
            }
            return View(save);
        }
    }
}