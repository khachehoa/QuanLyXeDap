using CleanArchitecture.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICTNhapHangS
    {
        IEnumerable<CTNhapHangViewModel> GetCTNhapHangs();

        void Create(CTNhapHangViewModel ctnhap);

        void remove(int? id);

        CTNhapHangViewModel GetCTNhapHang(int? iD);
        ICollection<CTNhapHangViewModel> GetCTNhaps(int? Id);
    }
}
