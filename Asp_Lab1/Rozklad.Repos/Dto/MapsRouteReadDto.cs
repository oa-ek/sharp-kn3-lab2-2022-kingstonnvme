using Microsoft.AspNetCore.Identity;
using Rozklad.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repos.Dto
{
    public class MapsRouteReadDto
    {

        public int mapsRouteId { get; set; }

        public float CoordinateOfDeparture { get; set; }

        public float CoordinateOfArrival { get; set; }

    }
}
