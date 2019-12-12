using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Models
{
    public partial class NhapHang
    {
        public NhapHang()
        {
            CtnhapHang = new HashSet<CtnhapHang>();
        }

        public int Id { get; set; }
        public int? IdnguoiDung { get; set; }
        public string Ngaymua { get; set; }
        public int? Gia { get; set; }

        public virtual NguoiDung IdnguoiDungNavigation { get; set; }
        public virtual ICollection<CtnhapHang> CtnhapHang { get; set; }
    }
}
