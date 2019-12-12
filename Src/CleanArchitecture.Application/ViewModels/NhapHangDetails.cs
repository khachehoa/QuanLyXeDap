using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.ViewModels
{
    public class NhapHangDetails
    {
        public NhapHangViewModel nhaphang { get; set; }
        public IEnumerable<CTNhapHangViewModel> ctnhaphang { get; set; }
    }
}
