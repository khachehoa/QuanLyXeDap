using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICTNhapHangR
    {
        IEnumerable<CtnhapHang> GetCtnhapHangs();
        void Add(CtnhapHang ctnhaphang);

        void Remove(int? id);

        CtnhapHang GetCtnhapHang(int? iD);
        ICollection<CtnhapHang> GetHangs(int? Id);
    }
}
