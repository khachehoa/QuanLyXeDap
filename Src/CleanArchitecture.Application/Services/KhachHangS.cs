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
    public class KhachHangS : IKhachHangS
    {
        private readonly IKhachHangR ikhachhangr;
        private readonly IMapper iMapper;

        public KhachHangS(IKhachHangR ikhachhangr, IMapper mapper)
        {
            this.ikhachhangr = ikhachhangr;
            this.iMapper = mapper;
        }
        public void Create(KhachHangViewModel khachhang)
        {
            var kh = iMapper.Map<KhachHangViewModel, KhachHang>(khachhang);
            ikhachhangr.Add(kh);
        }

        public KhachHangViewModel GetKhachHang(int? iD)
        {
            var kh = ikhachhangr.GetKhachHang(iD);
            return iMapper.Map<KhachHang, KhachHangViewModel>(kh);
        }

        public IEnumerable<KhachHangViewModel> GetKhachHangs()
        {
            var kh = ikhachhangr.GetKhachHangs();
            return iMapper.Map<IEnumerable<KhachHang>, IEnumerable<KhachHangViewModel>>(kh);
        }

        public void remove(int? id)
        {
            ikhachhangr.Remove(id);
        }
    }
}
