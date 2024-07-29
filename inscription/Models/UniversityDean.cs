using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inscription.Models
{
    public class UniversityDean
    {
        public int Id { get; set; }
        public string? NameDean { get; set; }
        public int UniversityId { get; set; }
        public University? University { get; set; }
    }
}