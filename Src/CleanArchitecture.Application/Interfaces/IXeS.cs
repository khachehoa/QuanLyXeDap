using CleanArchitecture.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IXeS
    {
        IEnumerable<XeViewModel> GetXeS();

        void Create(XeViewModel xe);

        void remove(int? id);

        XeViewModel GetXe(int? iD);
    }
}
