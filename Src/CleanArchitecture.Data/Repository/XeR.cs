using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Data.Repository
{
    public class XeR : IXeR
    {
        private WebEnglishDBContext webEnglishDBContext;

        public XeR(WebEnglishDBContext webEnglishDBContext)
        {
            this.webEnglishDBContext = webEnglishDBContext;
        }
        public void Add(Xe xe)
        {
            if (xe.Id == 0)
            {
                webEnglishDBContext.Xe.Add(xe);
                webEnglishDBContext.SaveChanges();
            }
            else
            {
                Xe findResults = webEnglishDBContext.Xe.Find(xe.Id);
                findResults.Ten = xe.Ten;
                findResults.Loai = xe.Loai;
                findResults.Idncc = xe.Idncc;
                findResults.Gia = xe.Gia;
                findResults.Soluong = xe.Soluong;
                
                webEnglishDBContext.SaveChanges();
            }
        }

        public Xe GetXe(int? iD)
        {
            Xe findResults = webEnglishDBContext.Xe.Find(iD);
            findResults.IdnccNavigation = webEnglishDBContext.NhaCungCap.Find(findResults.Idncc);
            return findResults;
        }

        public IEnumerable<Xe> GetXes()
        {
            return webEnglishDBContext.Xe.Include(g => g.IdnccNavigation);
        }

        public void Remove(int? id)
        {
            Xe findResults = webEnglishDBContext.Xe.Find(id);
            webEnglishDBContext.Remove(findResults);
            webEnglishDBContext.SaveChanges();
        }
    }
}
