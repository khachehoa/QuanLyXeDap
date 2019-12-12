using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectur.MVC.Controllers
{
    
    public class NguoiDungController : Controller
    {
        private INguoiDungService iNguoiDungService;

        public NguoiDungController(INguoiDungService iNguoiDungService)
        {
            this.iNguoiDungService = iNguoiDungService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("VaiTro") != "NguoiQuanTri")
            {
                return Redirect(@"~/NguoiDung/Login");
            } else
            {
                ViewBag.Name = HttpContext.Session.GetString("Ten");
                return View(iNguoiDungService.GetNguoiDungs());
            }
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("VaiTro") == "NguoiQuanTri")
            {
                return View();
            }
            return Redirect(@"~/NguoiDung/Login");
        }

        [HttpPost]
        public IActionResult Create(NguoiDungViewModel save)
        {
            if (ModelState.IsValid)
            {
                save.Id = 0;
                iNguoiDungService.Create(save);
                return RedirectToAction("Index");
            }
            return View(save);
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
                if (HttpContext.Session.GetString("VaiTro") == "NguoiQuanTri")
                {

                    ViewBag.Name = HttpContext.Session.GetString("Ten");
                    var nguoi = iNguoiDungService.GetNguoiDung(Id);
                    return View(nguoi);
                }
                return RedirectToAction("Login");
            }
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
                if (HttpContext.Session.GetString("VaiTro") == "NguoiQuanTri")
                {
                    ViewBag.Name = HttpContext.Session.GetString("Ten");
                    return View();
                }
                return Redirect(@"~/NguoiDung/Login");
                
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            iNguoiDungService.remove(Id); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult Login(NguoiDungViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = iNguoiDungService.Login(loginModel.TaiKhoan, loginModel.MatKhau);
                if (result != null)
                {
                    HttpContext.Session.SetString("ID", result.Id + "");
                    HttpContext.Session.SetString("VaiTro", result.VaiTro + "");
                    HttpContext.Session.SetString("Ten", result.TenNguoiDung + "");
                    ViewBag.DNTC = "Đăng Nhập Thành Công";
                    ViewBag.Name = result.TenNguoiDung;
                    return Redirect(@"~/Xe/Index");
                }
                else
                {
                    ViewBag.KTC = "Tên Đăng Nhập Hoặc Mật Khẩu Không Đúng";
                }
            }
            return View(loginModel);
        }


    }
}