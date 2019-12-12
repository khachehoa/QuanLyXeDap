using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public string Ngaysinh { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
