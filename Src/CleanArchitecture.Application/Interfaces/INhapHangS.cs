using CleanArchitecture.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces
{
    public interface INhapHangS
    {
        IEnumerable<NhapHangViewModel> GetNhapHangs();

        void Create(NhapHangViewModel nhaphang);

        void remove(int? id);

        NhapHangViewModel GetNhapHang(int? iD);
    }
}
