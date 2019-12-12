using CleanArchitecture.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces
{
    public interface INhaCungCapS
    {
        IEnumerable<NhaCungCapViewModel> GetNhaCungCaps();

        void Create(NhaCungCapViewModel nhacungcap);

        void remove(int? id);

        NhaCungCapViewModel GetNhaCungCap(int? iD);
    }
}
