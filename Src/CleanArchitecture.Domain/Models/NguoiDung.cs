using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Models
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            HoaDon = new HashSet<HoaDon>();
            NhapHang = new HashSet<NhapHang>();
        }

        public int Id { get; set; }
        public string TenNguoiDung { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public DateTime? NgayTao { get; set; }
        public string SoDienThoai { get; set; }
        public string Gmail { get; set; }
        public int? VaiTro { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
        public virtual ICollection<NhapHang> NhapHang { get; set; }
    }
}
