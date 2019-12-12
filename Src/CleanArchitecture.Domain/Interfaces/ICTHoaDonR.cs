using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICTHoaDonR
    {
        IEnumerable<CthoaDon> GetCTHoaDonRs();
        void Add(CthoaDon cthoadon);

        void Remove(int? id);

        CthoaDon GetCTHoaDon(int? iD);
        ICollection<CthoaDon> GetCTHoaRs(int? Id);
    }
}
