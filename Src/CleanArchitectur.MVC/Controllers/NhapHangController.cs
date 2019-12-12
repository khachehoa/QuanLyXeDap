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
    public class NhapHangController : Controller
    {
        private INguoiDungService nguoidungs;
        private INhapHangS nhaphangs;
        private IXeS ixes;
        private ICTNhapHangS ictnhaphangs;
        static int idnhaphang;
        public NhapHangController(INhapHangS nhaphangs, INguoiDungService nguoidungs,IXeS ixes, ICTNhapHangS ictnhaphangs)
        {
            this.nhaphangs = nhaphangs;
            this.nguoidungs = nguoidungs;
            this.ixes = ixes;
            this.ictnhaphangs = ictnhaphangs;
           
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
                return View(nhaphangs.GetNhapHangs());
            }
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Name = HttpContext.Session.GetString("Ten");
            ViewBag.NguoiDung = nguoidungs.GetNguoiDungs(); 
            return View();
        }

        [HttpPost]
        public IActionResult Create(NhapHangViewModel save)
        {
            if (ModelState.IsValid)
            {
                save.Id = 0;
                save.Gia = 0;
                nhaphangs.Create(save);
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
                var hd = nhaphangs.GetNhapHang(Id);
                return View(hd);
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            nhaphangs.remove(Id);
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
                ViewBag.NguoiDung = nguoidungs.GetNguoiDungs();
                var hd = nhaphangs.GetNhapHang(Id);
                return View(hd);
            }
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditConfirm(NhapHangViewModel save)
        {
            if (ModelState.IsValid)
            {
                NhapHangViewModel nh = nhaphangs.GetNhapHang(save.Id);
                save.Gia = nh.Gia;
                nhaphangs.Create(save);
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
                var nhapHangDetails = new NhapHangDetails()
                {
                    nhaphang = nhaphangs.GetNhapHang(Id),
                    ctnhaphang = ictnhaphangs.GetCTNhaps(Id)
                };
                idnhaphang = nhapHangDetails.nhaphang.Id;
                return View(nhapHangDetails);
            }
        }
        [HttpGet]
        public IActionResult CreateCTHD()
        {
            ViewBag.Name = HttpContext.Session.GetString("Ten");
            ViewBag.nhaphang = nhaphangs.GetNhapHangs();
            ViewBag.Xe = ixes.GetXeS();
            return View();
        }

        [HttpPost]
        public IActionResult CreateCTHD(CTNhapHangViewModel save)
        {
            if (ModelState.IsValid)
            {
                save.Id = 0;
                save.IdnhapHang = idnhaphang;
                ictnhaphangs.Create(save);
                XeViewModel xe = ixes.GetXe(save.Idxe);
                xe.Soluong += save.Soluong;
                ixes.Create(xe);
                NhapHangViewModel nhaphang = nhaphangs.GetNhapHang(save.IdnhapHang);
                nhaphang.Gia += xe.Gia * save.Soluong;
                nhaphangs.Create(nhaphang);
                return RedirectToAction("Index");
            }
            return View(save);
        }

        [HttpGet]
        public IActionResult DeleteCT(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.Name = HttpContext.Session.GetString("Ten");
                var hd = ictnhaphangs.GetCTNhapHang(Id);
                XeViewModel xe = ixes.GetXe(hd.Idxe);
                xe.Soluong -= hd.Soluong;
                ixes.Create(xe);
                NhapHangViewModel nhaphang = nhaphangs.GetNhapHang(hd.IdnhapHang);
                nhaphang.Gia -= xe.Gia * hd.Soluong;
                nhaphangs.Create(nhaphang);
                return View(hd);
            }
        }

        [HttpPost, ActionName("DeleteCT")]
        public IActionResult DeleteConfirmCT(int? Id)
        {
            ictnhaphangs.remove(Id);
            return RedirectToAction("Index");
        }
    }
}