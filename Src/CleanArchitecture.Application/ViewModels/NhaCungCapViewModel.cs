using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchitecture.Application.ViewModels
{
    public class NhaCungCapViewModel
    {
        [Key]
       
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }
    }
}
