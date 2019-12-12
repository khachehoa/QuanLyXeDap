using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IHoaDonR 
    {
        IEnumerable<HoaDon> GetHoaDons();
        void Add(HoaDon hoadon);

        void Remove(int? id);

        HoaDon GetHoaDon(int? iD);
    }
}
