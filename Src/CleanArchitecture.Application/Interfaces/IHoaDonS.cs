using CleanArchitecture.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IHoaDonS
    {
        IEnumerable<HoaDonViewModel> GetHoaDons();

        void Create(HoaDonViewModel hoadon);

        void remove(int? id);

        HoaDonViewModel GetHoaDon(int? iD);
    }
}
