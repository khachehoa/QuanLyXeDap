using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.ViewModels
{
    public class CTNhapHangViewModel
    {
        public int Id { get; set; }
        public int? IdnhapHang { get; set; }
        public int? Idxe { get; set; }
        public int? Soluong { get; set; }

        public virtual NhapHangViewModel IdnhapHangNavigation { get; set; }
        public virtual XeViewModel IdxeNavigation { get; set; }
    }
}
