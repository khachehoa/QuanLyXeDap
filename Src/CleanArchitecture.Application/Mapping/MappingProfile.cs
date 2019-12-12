using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NguoiDungViewModel, NguoiDung>();
            CreateMap<NguoiDung, NguoiDungViewModel>();

            CreateMap<NhaCungCapViewModel, NhaCungCap>();
            CreateMap<NhaCungCap, NhaCungCapViewModel>();

            CreateMap<XeViewModel, Xe>();
            CreateMap<Xe, XeViewModel>();

            CreateMap<KhachHangViewModel, KhachHang>();
            CreateMap<KhachHang, KhachHangViewModel>();

            CreateMap<HoaDonViewModel, HoaDon>();
            CreateMap<HoaDon, HoaDonViewModel>();

            CreateMap<CTHoaDonViewModel, CthoaDon>();
            CreateMap<CthoaDon, CTHoaDonViewModel>();

            CreateMap<NhapHangViewModel, NhapHang>();
            CreateMap<NhapHang, NhapHangViewModel>();

            CreateMap<CTNhapHangViewModel, CtnhapHang>();
            CreateMap<CtnhapHang, CTNhapHangViewModel>();
        }
    }
}
