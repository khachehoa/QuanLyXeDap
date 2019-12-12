using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Services
{
    public class XeS : IXeS
    {
        private readonly IXeR ixer;
        private readonly IMapper iMapper;
        public XeS(IXeR ixer, IMapper mapper)
        {
            this.ixer = ixer;
            this.iMapper = mapper;
        }
        public void Create(XeViewModel xe)
        {
            var xee = iMapper.Map<XeViewModel, Xe>(xe);
            ixer.Add(xee);
        }

        public XeViewModel GetXe(int? iD)
        {
            var xee = ixer.GetXe(iD);
            return iMapper.Map<Xe, XeViewModel>(xee);
        }

        public IEnumerable<XeViewModel> GetXeS()
        {
            var xee = ixer.GetXes();
            return iMapper.Map<IEnumerable<Xe>, IEnumerable<XeViewModel>>(xee);
        }

        public void remove(int? id)
        {
            ixer.Remove(id);
        }
    }
}
