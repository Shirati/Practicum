using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class UserDTO
    {
        public int NumUser { get; set; }

        public string? IdUser { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? Date { get; set; }

        public string? MaleOrFemale { get; set; }

        public string? Hmo { get; set; }

        public List<ChildDTO> Children { get; set; } = new List<ChildDTO>();
    }
}
