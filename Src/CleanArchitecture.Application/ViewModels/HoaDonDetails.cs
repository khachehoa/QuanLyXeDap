using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.ViewModels
{
    public class HoaDonDetails
    {
        public HoaDonViewModel hoadon { get; set; }
        public IEnumerable<CTHoaDonViewModel> cthoadons { get; set; }
    }
}
