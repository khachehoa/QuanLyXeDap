using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CleanArchitectur.MVC.Controllers
{
    public class HoaDonController : Controller
    {
        private IHoaDonS ihoadons;
        private INguoiDungService inguoiDungs;
        private IKhachHangS ikhachhangs;
        private ICTHoaDonS icthoadons;
        private IXeS ixes;
        static int idhoadon;
        public HoaDonController(IHoaDonS ihoadons, INguoiDungService inguoiDungs, IKhachHangS ikhachhangs, ICTHoaDonS icthoadons, IXeS ixes)
        {
            this.ihoadons = ihoadons;
            this.inguoiDungs = inguoiDungs;
            this.ikhachhangs = ikhachhangs;
            this.icthoadons = icthoadons;
            this.ixes = ixes;
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
                return View(ihoadons.GetHoaDons());
            }
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Name = HttpContext.Session.GetString("Ten");
            ViewBag.NguoiDung = inguoiDungs.GetNguoiDungs();
            ViewBag.KhachHang = ikhachhangs.GetKhachHangs();
            return View();
        }

        [HttpPost]
        public IActionResult Create(HoaDonViewModel save)
        {
            if (ModelState.IsValid)
            {
                save.Id = 0;
                save.Gia = 0;
                ihoadons.Create(save);
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
                var hd = ihoadons.GetHoaDon(Id);
                return View(hd);
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            ihoadons.remove(Id);
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
                ViewBag.NguoiDung = inguoiDungs.GetNguoiDungs();
                ViewBag.KhachHang = ikhachhangs.GetKhachHangs();
                var hd = ihoadons.GetHoaDon(Id);
                return View(hd);
            }
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditConfirm(HoaDonViewModel save)
        {
            if (ModelState.IsValid)
            {
                HoaDonViewModel hd = ihoadons.GetHoaDon(save.Id);
                save.Gia = hd.Gia;
                ihoadons.Create(save);
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
                var hoadonDetails = new HoaDonDetails()
                {
                    hoadon = ihoadons.GetHoaDon(Id),
                    cthoadons = icthoadons.getCTHoaS(Id)
                };
                idhoadon = hoadonDetails.hoadon.Id;
                return View(hoadonDetails);
            }
        }
        [HttpGet]
        public IActionResult CreateCTHD()
        {
            ViewBag.Name = HttpContext.Session.GetString("Ten");
            ViewBag.HoaDon = ihoadons.GetHoaDons();
            ViewBag.Xe= ixes.GetXeS();
            return View();
        }

        [HttpPost]
        public IActionResult CreateCTHD(CTHoaDonViewModel save)
        {
            if (ModelState.IsValid)
            {
                save.Id = 0;
                save.IdhoaDon = idhoadon;
                icthoadons.Create(save);
                XeViewModel xe = ixes.GetXe(save.Idxe);
                xe.Soluong -= save.Soluong;
                ixes.Create(xe);
                HoaDonViewModel hoadon = ihoadons.GetHoaDon(save.IdhoaDon);
                hoadon.Gia += xe.Gia * save.Soluong;
                ihoadons.Create(hoadon);
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
                var hd = icthoadons.GetCTHoaDon(Id);
                XeViewModel xe = ixes.GetXe(hd.Idxe);
                xe.Soluong += hd.Soluong;
                ixes.Create(xe);
                HoaDonViewModel hoadon = ihoadons.GetHoaDon(hd.IdhoaDon);
                hoadon.Gia -= xe.Gia * hd.Soluong;
                ihoadons.Create(hoadon);
                return View(hd);
            }
        }

        [HttpPost, ActionName("DeleteCT")]
        public IActionResult DeleteConfirmCT(int? Id)
        {
            icthoadons.remove(Id);
            return RedirectToAction("Index");
        }
    }
}