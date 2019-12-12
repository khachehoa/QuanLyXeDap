using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface INhapHangR
    {
        IEnumerable<NhapHang> GetNhapHangs();
        void Add(NhapHang nhaphang);

        void Remove(int? id);

        NhapHang GetNhapHang(int? iD);
    }
}
