using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Core
{
    public class MapsRoute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int mapsRouteId { get; set; }

        public float CoordinateOfDeparture { get; set; }

        public float CoordinateOfArrival { get; set; }

        public virtual ICollection<BusRoute> BusRoutes { get; set; }
    }
}
