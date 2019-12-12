using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            CthoaDon = new HashSet<CthoaDon>();
        }

        public int Id { get; set; }
        public int? IdnguoiDung { get; set; }
        public int? IdkhachHang { get; set; }
        public string Ngaymua { get; set; }
        public int? Gia { get; set; }

        public virtual KhachHang IdkhachHangNavigation { get; set; }
        public virtual NguoiDung IdnguoiDungNavigation { get; set; }
        public virtual ICollection<CthoaDon> CthoaDon { get; set; }
    }
}
