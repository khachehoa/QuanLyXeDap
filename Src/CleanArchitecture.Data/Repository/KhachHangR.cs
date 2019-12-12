using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Data.Repository
{
    public class KhachHangR : IKhachHangR
    {
        private WebEnglishDBContext webEnglishDBContext;

        public KhachHangR(WebEnglishDBContext webEnglishDBContext)
        {
            this.webEnglishDBContext = webEnglishDBContext;
        }
        public void Add(KhachHang khachhang)
        {
            if (khachhang.Id == 0)
            {
                webEnglishDBContext.KhachHang.Add(khachhang);
                webEnglishDBContext.SaveChanges();
            }
            else
            {
                KhachHang findResults = webEnglishDBContext.KhachHang.Find(khachhang.Id);
                findResults.Ten = khachhang.Ten;
                findResults.Sdt = khachhang.Sdt;
                findResults.Diachi = khachhang.Diachi;
                findResults.Ngaysinh = khachhang.Ngaysinh;
                webEnglishDBContext.SaveChanges();
            }
        }

        public KhachHang GetKhachHang(int? iD)
        {
            KhachHang findResults = webEnglishDBContext.KhachHang.Find(iD);
            return findResults;
        }

        public IEnumerable<KhachHang> GetKhachHangs()
        {
            return webEnglishDBContext.KhachHang;
        }

        public void Remove(int? id)
        {
            KhachHang findResults = webEnglishDBContext.KhachHang.Find(id);
            webEnglishDBContext.Remove(findResults);
            webEnglishDBContext.SaveChanges();
        }
    }
}
