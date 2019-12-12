using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Mapping;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Data.Context;
using CleanArchitecture.Data.Repository;
using CleanArchitecture.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Layer
            services.AddScoped<INguoiDungService, NguoiDungService>();

            // Infrastructure.Data
            services.AddScoped<INguoiDungRepository, NguoiDungRepository>();

            
            services.AddScoped<INhaCungCapS, NhaCungCapS>();
            services.AddScoped<INhaCungCapR, NhaCungCapR>();

            services.AddScoped<IXeS, XeS>();
            services.AddScoped<IXeR, XeR>();

            services.AddScoped<IKhachHangS, KhachHangS>();
            services.AddScoped<IKhachHangR, KhachHangR>();

            services.AddScoped<IHoaDonS, HoaDonS>();
            services.AddScoped<IHoaDonR, HoaDonR>();

            services.AddScoped<ICTHoaDonS, CTHoaDonS>();
            services.AddScoped<ICTHoaDonR, CTHoaDonR>();

            services.AddScoped<INhapHangS, NhapHangS>();
            services.AddScoped<INhapHangR, NhapHangR>();

            services.AddScoped<ICTNhapHangS, CTNhapHangS>();
            services.AddScoped<ICTNhapHangR, CTNhapHangR>();

            services.AddScoped<WebEnglishDBContext>();
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
