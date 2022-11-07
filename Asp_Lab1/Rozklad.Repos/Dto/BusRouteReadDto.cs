using Microsoft.AspNetCore.Identity;
using Rozklad.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repos.Dto
{
    public class BusRouteReadDto
    {
        public int BusrouteId { get; set; }

        public string PlaceOfDeparture { get; set; }

        public string IntermediateStops { get; set; }

        public string PlaceOfArrival { get; set; }

        public int mapsRouteId { get; set; }
        public MapsRouteReadDto mapsRoute { get; set; }

    }
}
