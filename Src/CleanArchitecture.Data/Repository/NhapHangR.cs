using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Data.Repository
{
    public class NhapHangR : INhapHangR
    {
        private WebEnglishDBContext webEnglishDBContext;

        public NhapHangR(WebEnglishDBContext webEnglishDBContext)
        {
            this.webEnglishDBContext = webEnglishDBContext;
        }
        public void Add(NhapHang nhaphang)
        {
            if (nhaphang.Id == 0)
            {
                webEnglishDBContext.NhapHang.Add(nhaphang);
                webEnglishDBContext.SaveChanges();
            }
            else
            {
                NhapHang findResults = webEnglishDBContext.NhapHang.Find(nhaphang.Id);
                findResults.IdnguoiDung = nhaphang.IdnguoiDung;                
                findResults.Ngaymua = nhaphang.Ngaymua;
                findResults.Gia = nhaphang.Gia;
                webEnglishDBContext.SaveChanges();
            }
        }

        public NhapHang GetNhapHang(int? iD)
        {
            NhapHang findResults = webEnglishDBContext.NhapHang.Find(iD);
            findResults.IdnguoiDungNavigation = webEnglishDBContext.NguoiDung.Find(findResults.IdnguoiDung);
            return findResults;
        }

        public IEnumerable<NhapHang> GetNhapHangs()
        {
            return webEnglishDBContext.NhapHang.Include(g => g.IdnguoiDungNavigation);
        }

        public void Remove(int? id)
        {
            NhapHang findResults = webEnglishDBContext.NhapHang.Find(id);
            webEnglishDBContext.Remove(findResults);
            webEnglishDBContext.SaveChanges();
        }
    }
}
