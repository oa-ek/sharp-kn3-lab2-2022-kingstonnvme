using Microsoft.AspNetCore.Identity;
using Rozklad.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repos.Dto
{
    public class BusSheduleReadDto
    {
        public int Id { get; set; }
        public int BusrouteId { get; set; }
        public BusRouteReadDto Busrooute { get; set; }
        public DateTime DepartureTime { get; set; }
        public int Seats { get; set; }
        public int carrierId { get; set; }
        public CarrierReadDto carier { get; set; }
        public DateTime ArrivalTime { get; set; }
        public float Cost { get; set; }
        public int statusId { get; set; }
        public StatusReadDto status { get; set; }


    }
}
