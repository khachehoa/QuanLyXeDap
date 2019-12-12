using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchitecture.Application.ViewModels
{
    public class XeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Loai { get; set; }
        public int? Idncc { get; set; }
        public int? Soluong { get; set; }
        public int? Gia { get; set; }
        public virtual NhaCungCapViewModel IdnccNavigation { get; set; }
    }
}
