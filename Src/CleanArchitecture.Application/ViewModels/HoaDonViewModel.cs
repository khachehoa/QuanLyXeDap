using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.ViewModels
{
    public class HoaDonViewModel
    {
        public int Id { get; set; }
        public int? IdnguoiDung { get; set; }
        public int? IdkhachHang { get; set; }
        public string Ngaymua { get; set; }
        public int? Gia { get; set; }

        public virtual KhachHangViewModel IdkhachHangNavigation { get; set; }
        public virtual NguoiDungViewModel IdnguoiDungNavigation { get; set; }
    }
}
