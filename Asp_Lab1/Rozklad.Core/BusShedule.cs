using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Core
{
    public class BusShedule
    {
        [Key]

        public int Id { get; set; }

        public DateTime DepartureTime { get; set; }

        public BusRoute Busroute { get; set; }

        public int Seats { get; set; }

        public string Status    { get; set; }
        public Carrier carrier { get; set; }
        
        public DateTime ArrivalTime { get; set; }

        public float Cost { get; set; }    

       
    }
}
