using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.ViewModels
{
    public class CTHoaDonViewModel
    {
        public int Id { get; set; }
        public int? IdhoaDon { get; set; }
        public int? Idxe { get; set; }
        public int? Soluong { get; set; }

        public virtual HoaDonViewModel IdhoaDonNavigation { get; set; }
        public virtual XeViewModel IdxeNavigation { get; set; }
    }
}
