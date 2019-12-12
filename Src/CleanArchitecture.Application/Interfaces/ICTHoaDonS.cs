using CleanArchitecture.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICTHoaDonS
    {
        IEnumerable<CTHoaDonViewModel> GetCTHoaDons();

        void Create(CTHoaDonViewModel cthoadon);

        void remove(int? id);

        CTHoaDonViewModel GetCTHoaDon(int? iD);
        ICollection<CTHoaDonViewModel> getCTHoaS(int? Id);
    }
}
