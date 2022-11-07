using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Core
{
    public class BusRoute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BusrouteId { get; set; }

        public string PlaceOfDeparture { get; set; }

        public string IntermediateStops { get; set; }

        public string PlaceOfArrival { get; set; }

       // public int mapsRouteId { get; set; }
        //public MapsRoute? mapsRoute { get; set; }

        public virtual ICollection<BusShedule>? BusShedules { get; set; }
    }
}
