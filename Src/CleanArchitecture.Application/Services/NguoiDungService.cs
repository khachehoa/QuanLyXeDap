using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.Services
{
    public class NguoiDungService : INguoiDungService
    {
        private readonly INguoiDungRepository iNguoiDungRepository;
        private readonly IMapper iMapper;

        public NguoiDungService(INguoiDungRepository iNguoiDungRepository, IMapper mapper)
        {
            this.iNguoiDungRepository = iNguoiDungRepository;
            this.iMapper = mapper;
        }

        public void Create(NguoiDungViewModel nguoiDung)
        {
            var nguoi = iMapper.Map<NguoiDungViewModel, NguoiDung>(nguoiDung);
            iNguoiDungRepository.Add(nguoi);
        }

        public NguoiDungViewModel GetNguoiDung(int? iD)
        {
            var nguoi = iNguoiDungRepository.GetNguoiDung(iD);
            return iMapper.Map<NguoiDung, NguoiDungViewModel>(nguoi);
        }

        public IEnumerable<NguoiDungViewModel> GetNguoiDungs()
        {
            var nguoi = iNguoiDungRepository.GetNguoiDungs();
            return iMapper.Map<IEnumerable<NguoiDung>, IEnumerable<NguoiDungViewModel>>(nguoi);
        }

        public NguoiDungViewModel Login(string tenDangNhap, string matKhau)
        {
            return iMapper.Map<NguoiDung, NguoiDungViewModel>(iNguoiDungRepository.Login(tenDangNhap, matKhau));
        }

        public void remove(int? id)
        {
            iNguoiDungRepository.Remove(id);
        }

       
    }
}
