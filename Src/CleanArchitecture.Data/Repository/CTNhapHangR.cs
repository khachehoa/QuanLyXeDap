using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Data.Repository
{
    public class CTNhapHangR : ICTNhapHangR
    {
        private WebEnglishDBContext webEnglishDBContext;

        public CTNhapHangR(WebEnglishDBContext webEnglishDBContext)
        {
            this.webEnglishDBContext = webEnglishDBContext;
        }
        public void Add(CtnhapHang ctnhaphang)
        {
            if (ctnhaphang.Id == 0)
            {
                webEnglishDBContext.CtnhapHang.Add(ctnhaphang);
                webEnglishDBContext.SaveChanges();
            }
            else
            {
                CtnhapHang findResults = webEnglishDBContext.CtnhapHang.Find(ctnhaphang.Id);
                findResults.IdnhapHang = ctnhaphang.IdnhapHang;
                findResults.Idxe = ctnhaphang.Idxe;
                findResults.Soluong = ctnhaphang.Soluong;
                webEnglishDBContext.SaveChanges();
            }
        }

        public CtnhapHang GetCtnhapHang(int? iD)
        {
            CtnhapHang findResults = webEnglishDBContext.CtnhapHang.Find(iD);
            findResults.IdnhapHangNavigation = webEnglishDBContext.NhapHang.Find(findResults.IdnhapHang);
            findResults.IdxeNavigation = webEnglishDBContext.Xe.Find(findResults.Idxe);
            return findResults;
        }

        public IEnumerable<CtnhapHang> GetCtnhapHangs()
        {
            return webEnglishDBContext.CtnhapHang.Include(g => g.IdnhapHangNavigation).Include(g => g.IdxeNavigation);
        }

        public ICollection<CtnhapHang> GetHangs(int? Id)
        {
            var cthd = from m in webEnglishDBContext.CtnhapHang.Include(g => g.IdnhapHangNavigation).Include(g => g.IdxeNavigation)
                       where m.IdnhapHang == Id
                       select m;
            return cthd.Distinct().ToList();
        }

        public void Remove(int? id)
        {
            CtnhapHang findResults = webEnglishDBContext.CtnhapHang.Find(id);
            webEnglishDBContext.Remove(findResults);
            webEnglishDBContext.SaveChanges();
        }
    }
}
