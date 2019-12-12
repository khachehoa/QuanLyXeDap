using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Models
{
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            Xe = new HashSet<Xe>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }

        public virtual ICollection<Xe> Xe { get; set; }
    }
}
