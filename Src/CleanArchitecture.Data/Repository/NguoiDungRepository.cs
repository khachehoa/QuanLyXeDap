﻿using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Interfaces;
using System.Linq;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Data.Context;

namespace CleanArchitecture.Data.Repository
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        private WebEnglishDBContext webEnglishDBContext;

        public NguoiDungRepository(WebEnglishDBContext webEnglishDBContext)
        {
            this.webEnglishDBContext = webEnglishDBContext;
        }

        public void Add(NguoiDung nguoi)
        {
            if(nguoi.Id == 0)
            {
                webEnglishDBContext.NguoiDung.Add(nguoi);
                webEnglishDBContext.SaveChanges();
            } else
            {
                NguoiDung findResults = webEnglishDBContext.NguoiDung.Find(nguoi.Id);
                findResults.TenNguoiDung = nguoi.TenNguoiDung;
                findResults.TaiKhoan = nguoi.TaiKhoan;
                findResults.MatKhau = nguoi.MatKhau;
                findResults.SoDienThoai = nguoi.SoDienThoai;
                findResults.NgayTao = nguoi.NgayTao;
                findResults.Gmail = nguoi.Gmail;
                findResults.VaiTro = nguoi.VaiTro;
                webEnglishDBContext.SaveChanges();
            }
        }

        public NguoiDung GetNguoiDung(int? iD)
        {
            NguoiDung findResults = webEnglishDBContext.NguoiDung.Find(iD);
            return findResults;

        }

        public IEnumerable<NguoiDung> GetNguoiDungs()
        {
            return webEnglishDBContext.NguoiDung;
        }

        public NguoiDung Login(string tenDangNhap, string matKhau)
        {
            var nguoiDung = from m in webEnglishDBContext.NguoiDung
                            where m.TaiKhoan == tenDangNhap
                            select m;
            if (nguoiDung.Count() > 0)
            {
                if (nguoiDung.First().MatKhau == matKhau)
                {
                    return nguoiDung.First();
                }
                return null;
            }
            return null;
        }
        public void Remove(int? id)
        {
            NguoiDung findResults = webEnglishDBContext.NguoiDung.Find(id);
            webEnglishDBContext.Remove(findResults);
            webEnglishDBContext.SaveChanges();
        }
    }
}
