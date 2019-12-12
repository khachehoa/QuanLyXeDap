using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Data.Repository
{
    public class HoaDonR : IHoaDonR
    {
        private WebEnglishDBContext webEnglishDBContext;

        public HoaDonR(WebEnglishDBContext webEnglishDBContext)
        {
            this.webEnglishDBContext = webEnglishDBContext;
        }
        public void Add(HoaDon hoadon)
        {
            if (hoadon.Id == 0)
            {
                webEnglishDBContext.HoaDon.Add(hoadon);
                webEnglishDBContext.SaveChanges();
            }
            else
            {
                HoaDon findResults = webEnglishDBContext.HoaDon.Find(hoadon.Id);
                findResults.IdkhachHang = hoadon.IdkhachHang;
                findResults.IdnguoiDung = hoadon.IdnguoiDung;
                findResults.Ngaymua = hoadon.Ngaymua;
                findResults.Gia = hoadon.Gia;
                webEnglishDBContext.SaveChanges();
            }
        }

        public HoaDon GetHoaDon(int? iD)
        {
            HoaDon findResults = webEnglishDBContext.HoaDon.Find(iD);
            findResults.IdkhachHangNavigation = webEnglishDBContext.KhachHang.Find(findResults.IdkhachHang);
            findResults.IdnguoiDungNavigation = webEnglishDBContext.NguoiDung.Find(findResults.IdnguoiDung);
            return findResults;
        }

        public IEnumerable<HoaDon> GetHoaDons()
        {
            return webEnglishDBContext.HoaDon.Include(g => g.IdkhachHangNavigation).Include(g => g.IdnguoiDungNavigation);
        }

        public void Remove(int? id)
        {
            HoaDon findResults = webEnglishDBContext.HoaDon.Find(id);
            webEnglishDBContext.Remove(findResults);
            webEnglishDBContext.SaveChanges();
        }
    }
}
