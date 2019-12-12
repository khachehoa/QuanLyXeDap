using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface INhaCungCapR
    {
        IEnumerable<NhaCungCap> GetNhaCungCaps();
        void Add(NhaCungCap nhacungcap);

        void Remove(int? id);

        NhaCungCap getNhaCungCap(int? iD);
    }
}
