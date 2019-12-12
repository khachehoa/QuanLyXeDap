using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Models
{
    public partial class Xe
    {
        public Xe()
        {
            CthoaDon = new HashSet<CthoaDon>();
            CtnhapHang = new HashSet<CtnhapHang>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public string Loai { get; set; }
        public int? Idncc { get; set; }
        public int? Soluong { get; set; }
        public int? Gia { get; set; }

        public virtual NhaCungCap IdnccNavigation { get; set; }
        public virtual ICollection<CthoaDon> CthoaDon { get; set; }
        public virtual ICollection<CtnhapHang> CtnhapHang { get; set; }
    }
}
