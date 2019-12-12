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
    public class CTHoaDonR : ICTHoaDonR
    {
        private WebEnglishDBContext webEnglishDBContext;

        public CTHoaDonR(WebEnglishDBContext webEnglishDBContext)
        {
            this.webEnglishDBContext = webEnglishDBContext;
        }

        public void Add(CthoaDon cthoadon)
        {
            if (cthoadon.Id == 0)
            {
                webEnglishDBContext.CthoaDon.Add(cthoadon);
                webEnglishDBContext.SaveChanges();
            }
            else
            {
                CthoaDon findResults = webEnglishDBContext.CthoaDon.Find(cthoadon.Id);
                findResults.IdhoaDon = cthoadon.IdhoaDon;
                findResults.Idxe = cthoadon.Idxe;
                findResults.Soluong = cthoadon.Soluong;
                webEnglishDBContext.SaveChanges();
            }
        }

        public CthoaDon GetCTHoaDon(int? iD)
        {
            CthoaDon findResults = webEnglishDBContext.CthoaDon.Find(iD);
            findResults.IdhoaDonNavigation = webEnglishDBContext.HoaDon.Find(findResults.IdhoaDon);
            findResults.IdxeNavigation = webEnglishDBContext.Xe.Find(findResults.Idxe);
            return findResults;
        }

        public IEnumerable<CthoaDon> GetCTHoaDonRs()
        {
            return webEnglishDBContext.CthoaDon.Include(g => g.IdhoaDonNavigation).Include(g => g.IdxeNavigation);
        }

        public ICollection<CthoaDon> GetCTHoaRs(int? Id)
        {
            var cthd = from m in webEnglishDBContext.CthoaDon.Include(g => g.IdhoaDonNavigation).Include(g => g.IdxeNavigation)
                       where m.IdhoaDon == Id
                         select m;
            return cthd.Distinct().ToList();
        }

        public void Remove(int? id)
        {
            CthoaDon findResults = webEnglishDBContext.CthoaDon.Find(id);
            webEnglishDBContext.Remove(findResults);
            webEnglishDBContext.SaveChanges();
        }
    }
}
