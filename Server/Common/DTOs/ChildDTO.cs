using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class ChildDTO
    {
        public int NumChild { get; set; }

        public string? IdChild { get; set; }

        public string? Fullname { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? ParentId { get; set; }
     
    }
}
