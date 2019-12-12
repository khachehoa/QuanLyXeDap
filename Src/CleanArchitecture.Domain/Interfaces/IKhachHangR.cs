using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IKhachHangR
    {
        IEnumerable<KhachHang> GetKhachHangs();
        void Add(KhachHang khachhang);

        void Remove(int? id);

        KhachHang GetKhachHang(int? iD);
    }
}
