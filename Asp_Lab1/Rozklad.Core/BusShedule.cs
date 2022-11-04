using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Core
{
    public class BusShedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }

        public int BusrouteId { get; set; }
        public BusRoute? Busroute { get; set; }

       // public MapsRoute? mapsRoute { get; set; }
        public int? Seats { get; set; }

        public int carrierId { get; set; }
        public Carrier? carrier { get; set; }
        public int statusId { get; set; }
        public Status? status { get; set; }
        public DateTime ArrivalTime { get; set; }
        public float? Cost { get; set; }

        public int buyTicketId { get; set; }
        public BuyTicket? buyTicket { get; set; }
    }
}
