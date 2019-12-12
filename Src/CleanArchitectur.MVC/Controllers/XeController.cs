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
    public class XeController : Controller
    {
        private IXeS ixes;
        private INhaCungCapS inhacungcaps;
        public XeController(IXeS ixes, INhaCungCapS inhacungcaps)
        {
            this.ixes = ixes;
            this.inhacungcaps = inhacungcaps;
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
                return View(ixes.GetXeS());
            }
            
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Name = HttpContext.Session.GetString("Ten");
            ViewBag.NhaCungCap = inhacungcaps.GetNhaCungCaps();
            return View();
        }

        [HttpPost]
        public IActionResult Create(XeViewModel save)
        {
            if (ModelState.IsValid)
            {
                save.Id = 0;
                save.Soluong = 0;
                ixes.Create(save);
                
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
                var xee = ixes.GetXe(Id);
                return View(xee);
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            ixes.remove(Id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.Name = HttpContext.Session.GetString("Ten");
                ViewBag.NhaCungCap = inhacungcaps.GetNhaCungCaps();
                var xee = ixes.GetXe(Id);
                return View(xee);
            }
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditConfirm(XeViewModel save)
        {
            if (ModelState.IsValid)
            {
                
                XeViewModel x = ixes.GetXe(save.Id);
                save.Soluong = x.Soluong;
                ixes.Create(save);
                return RedirectToAction("Index");
            }
            return View(save);
        }
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.Name = HttpContext.Session.GetString("Ten");
                return View(ixes.GetXe(Id));
            }
        }
    }
}