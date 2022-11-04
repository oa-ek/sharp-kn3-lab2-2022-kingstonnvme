using Rozklad.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repos.Dto
{
   public class BusSheduleCreateDto
    {
        public int Id { get; set; }
        public int BusrouteId { get; set; }

        public int carrierId { get; set; }
        public int statusId { get; set; }

        [Required(ErrorMessage ="Введіть дату відбуття")]
        public DateTime DepartureTime { get; set; }

        
        [Required(ErrorMessage = "Введіть маршрут")]

        public BusRoute? Busroute { get; set; }
        [Required(ErrorMessage = "Введіть маршрут")]
        public MapsRoute? mapsRoute { get; set; }

        [Required(ErrorMessage = "Введіть кількість місць")]
        public int? Seats { get; set; }
      

        [Required(ErrorMessage = "Введіть інформацію про перевізника")]
        public Carrier? carrier { get; set; }

    

        [Required(ErrorMessage = "Введіть статус")]

        public Status? status { get; set; }

        [Required(ErrorMessage = "Введіть час прибуття")]

        public DateTime ArrivalTime { get; set; }

        [Required(ErrorMessage = "Введіть вартість одного квитка")]

        public float Cost { get; set; }








    }
}
