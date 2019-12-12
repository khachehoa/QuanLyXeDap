using CleanArchitecture.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IKhachHangS
    {
        IEnumerable<KhachHangViewModel> GetKhachHangs();

        void Create(KhachHangViewModel khachHang);

        void remove(int? id);

        KhachHangViewModel GetKhachHang(int? iD);
    }
}
