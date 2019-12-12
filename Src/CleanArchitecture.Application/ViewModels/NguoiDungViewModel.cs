using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.ViewModels
{
    public class NguoiDungViewModel
    {
        public int Id { get; set; }
        public string TenNguoiDung { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public DateTime? NgayTao { get; set; }
        public string SoDienThoai { get; set; }
        public string Gmail { get; set; }
        public VaiTroo VaiTro { get; set; }
        public enum VaiTroo
        {
            NhanVien = 1,
            NguoiQuanTri = 2
        }
    }
}
