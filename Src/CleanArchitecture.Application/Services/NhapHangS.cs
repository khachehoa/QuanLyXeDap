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
    public class NhapHangS : INhapHangS
    {
        private readonly INhapHangR nhaphangr;
        private readonly IMapper iMapper;
        public NhapHangS(INhapHangR nhaphangr, IMapper mapper)
        {
            this.nhaphangr = nhaphangr;
            this.iMapper = mapper;
        }
        public void Create(NhapHangViewModel nhaphang)
        {
            var hd = iMapper.Map<NhapHangViewModel, NhapHang>(nhaphang);
            nhaphangr.Add(hd);
        }

        public NhapHangViewModel GetNhapHang(int? iD)
        {
            var hd = nhaphangr.GetNhapHang(iD);
            return iMapper.Map<NhapHang, NhapHangViewModel>(hd);
        }

        public IEnumerable<NhapHangViewModel> GetNhapHangs()
        {
            var hd = nhaphangr.GetNhapHangs();
            return iMapper.Map<IEnumerable<NhapHang>, IEnumerable<NhapHangViewModel>>(hd);
        }

        public void remove(int? id)
        {
            nhaphangr.Remove(id);
        }
    }
}
