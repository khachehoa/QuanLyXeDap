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
    public class CTNhapHangS : ICTNhapHangS
    {
        private readonly ICTNhapHangR ictnhaphangr;
        private readonly IMapper iMapper;
        public CTNhapHangS(ICTNhapHangR ictnhaphangr, IMapper mapper)
        {
            this.ictnhaphangr = ictnhaphangr;
            this.iMapper = mapper;
        }
        public void Create(CTNhapHangViewModel ctnhap)
        {
            var cthd = iMapper.Map<CTNhapHangViewModel, CtnhapHang>(ctnhap);
            ictnhaphangr.Add(cthd);
        }

        public CTNhapHangViewModel GetCTNhapHang(int? iD)
        {
            var cthd = ictnhaphangr.GetCtnhapHang(iD);
            return iMapper.Map<CtnhapHang, CTNhapHangViewModel>(cthd);
        }

        public IEnumerable<CTNhapHangViewModel> GetCTNhapHangs()
        {
            var cthd = ictnhaphangr.GetCtnhapHangs();
            return iMapper.Map<IEnumerable<CtnhapHang>, IEnumerable<CTNhapHangViewModel>>(cthd);
        }

        public ICollection<CTNhapHangViewModel> GetCTNhaps(int? Id)
        {
            return iMapper.Map<ICollection<CtnhapHang>, ICollection<CTNhapHangViewModel>>(ictnhaphangr.GetHangs(Id));
        }

        public void remove(int? id)
        {
            ictnhaphangr.Remove(id);
        }
    }
}
