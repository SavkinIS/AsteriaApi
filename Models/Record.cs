using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsteriaApi.Models
{
    public class Record
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int SpecId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string TypeWork { get; set; }
        public int Price { get; set; }
    }
}
