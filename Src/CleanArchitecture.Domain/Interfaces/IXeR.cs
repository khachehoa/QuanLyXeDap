using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IXeR
    {
        IEnumerable<Xe> GetXes();
        void Add(Xe xe);

        void Remove(int? id);

        Xe GetXe(int? iD);
    }
}
