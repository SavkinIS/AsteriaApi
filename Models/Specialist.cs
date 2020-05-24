using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsteriaApi.Models
{
    public class Specialist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public bool Women { get; set; }
        public bool Men { get; set; }
        public bool Child { get; set; }
        public string Phone { get; set; }
        public string SpecAvatar { get; set; }

    }
}
