using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Data.Repository
{
    public class NhaCungCapR : INhaCungCapR
    {
        private WebEnglishDBContext webEnglishDBContext;

        public NhaCungCapR(WebEnglishDBContext webEnglishDBContext)
        {
            this.webEnglishDBContext = webEnglishDBContext;
        }
        public void Add(Domain.Models.NhaCungCap nhacungcap)
        {
            if (nhacungcap.Id == 0)
            {
                webEnglishDBContext.NhaCungCap.Add(nhacungcap);
                webEnglishDBContext.SaveChanges();
            }
            else
            {
                NhaCungCap findResults = webEnglishDBContext.NhaCungCap.Find(nhacungcap.Id);
                findResults.Ten = nhacungcap.Ten;
                findResults.Sdt = nhacungcap.Sdt;
                findResults.Diachi = nhacungcap.Diachi;
                webEnglishDBContext.SaveChanges();
            }
        }

        public Domain.Models.NhaCungCap getNhaCungCap(int? iD)
        {
            NhaCungCap findResults = webEnglishDBContext.NhaCungCap.Find(iD);
            return findResults;
        }

        public IEnumerable<Domain.Models.NhaCungCap> GetNhaCungCaps()
        {
            return webEnglishDBContext.NhaCungCap;
        }

        public void Remove(int? id)
        {
            NhaCungCap findResults = webEnglishDBContext.NhaCungCap.Find(id);
            webEnglishDBContext.Remove(findResults);
            webEnglishDBContext.SaveChanges();
        }
    }
}
