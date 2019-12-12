using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Models
{
    public partial class CthoaDon
    {
        public int Id { get; set; }
        public int? IdhoaDon { get; set; }
        public int? Idxe { get; set; }
        public int? Soluong { get; set; }

        public virtual HoaDon IdhoaDonNavigation { get; set; }
        public virtual Xe IdxeNavigation { get; set; }
    }
}
