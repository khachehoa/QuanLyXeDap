using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Models
{
    public partial class CtnhapHang
    {
        public int Id { get; set; }
        public int? IdnhapHang { get; set; }
        public int? Idxe { get; set; }
        public int? Soluong { get; set; }

        public virtual NhapHang IdnhapHangNavigation { get; set; }
        public virtual Xe IdxeNavigation { get; set; }
    }
}
