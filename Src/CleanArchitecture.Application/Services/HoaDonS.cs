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
    public class HoaDonS : IHoaDonS
    {
        private readonly IHoaDonR ihoadonr;
        private readonly IMapper iMapper;
        public HoaDonS(IHoaDonR ihoadonr, IMapper mapper)
        {
            this.ihoadonr = ihoadonr;
            this.iMapper = mapper;
        }
        public void Create(HoaDonViewModel hoadon)
        {
            var hd = iMapper.Map<HoaDonViewModel, HoaDon>(hoadon);
            ihoadonr.Add(hd);
        }

        public HoaDonViewModel GetHoaDon(int? iD)
        {
            var hd = ihoadonr.GetHoaDon(iD);
            return iMapper.Map<HoaDon, HoaDonViewModel>(hd);
        }

        public IEnumerable<HoaDonViewModel> GetHoaDons()
        {
            var hd = ihoadonr.GetHoaDons();
            return iMapper.Map<IEnumerable<HoaDon>, IEnumerable<HoaDonViewModel>>(hd);
        }

        public void remove(int? id)
        {
            ihoadonr.Remove(id);
        }
    }
}
