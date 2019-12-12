using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.ViewModels
{
    public class NhapHangViewModel
    {
        public int Id { get; set; }
        public int? IdnguoiDung { get; set; }
        public string Ngaymua { get; set; }
        public int? Gia { get; set; }

        public virtual NguoiDungViewModel IdnguoiDungNavigation { get; set; }
    }
}
