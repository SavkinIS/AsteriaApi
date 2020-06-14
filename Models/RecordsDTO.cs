using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsteriaApi.Models
{
    public class RecordsDTO
    {

        public int Id { get; set; }
        public string ClientName { get; set; }
        public int Clientid { get; set; }
        public string SpecName { get; set; }
        public int SpecId{ get; set; }

        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string TypeWork { get; set; }
        public int? Price { get; set; }
    }
}
