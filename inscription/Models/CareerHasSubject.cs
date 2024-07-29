using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inscription.Models
{
    public class CareerHasSubject
    {
        public int CareerId { get; set; }
        public Career? Career { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set;}

    }
}