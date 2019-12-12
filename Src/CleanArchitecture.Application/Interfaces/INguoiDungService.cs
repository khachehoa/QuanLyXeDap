using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Application.ViewModels;

namespace CleanArchitecture.Application.Interfaces
{
    public interface INguoiDungService
    {
        IEnumerable<NguoiDungViewModel> GetNguoiDungs();

        void Create(NguoiDungViewModel nguoiDung);

        void remove(int? id);

        NguoiDungViewModel GetNguoiDung(int? iD);
        public NguoiDungViewModel Login(string tenDangNhap, string matKhau);

    }
}
