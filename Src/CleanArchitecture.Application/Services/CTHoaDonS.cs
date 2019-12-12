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
    public class CTHoaDonS : ICTHoaDonS
    {
        private readonly ICTHoaDonR icthoadonr;
        private readonly IMapper iMapper;
        public CTHoaDonS(ICTHoaDonR icthoadonr, IMapper mapper)
        {
            this.icthoadonr = icthoadonr;
            this.iMapper = mapper;
        }
        public void Create(CTHoaDonViewModel cthoadon)
        {
            var cthd = iMapper.Map<CTHoaDonViewModel, CthoaDon>(cthoadon);
            icthoadonr.Add(cthd);
        }

        public CTHoaDonViewModel GetCTHoaDon(int? iD)
        {
            var cthd = icthoadonr.GetCTHoaDon(iD);
            return iMapper.Map<CthoaDon, CTHoaDonViewModel>(cthd);
        }

        public IEnumerable<CTHoaDonViewModel> GetCTHoaDons()
        {
            var cthd = icthoadonr.GetCTHoaDonRs();
            return iMapper.Map<IEnumerable<CthoaDon>, IEnumerable<CTHoaDonViewModel>>(cthd);
        }

        public ICollection<CTHoaDonViewModel> getCTHoaS(int? Id)
        {
            return iMapper.Map<ICollection<CthoaDon>, ICollection<CTHoaDonViewModel>>(icthoadonr.GetCTHoaRs(Id));
        }

        public void remove(int? id)
        {
            icthoadonr.Remove(id);
        }
    }
}
