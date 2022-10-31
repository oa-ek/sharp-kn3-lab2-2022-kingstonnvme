using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rozklad.Core;
using Rozklad.Repos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repos
{
    public class BusSheduleRepository
    {
        private readonly RozkladContext _ctx;
       
        public BusSheduleRepository(RozkladContext ctx)
        {
            _ctx = ctx;
           
        }
      

         public async Task<IEnumerable<BusSheduleReadDto>> GetBusSheduleAsync()
         {
         

            var shedules = new List<BusSheduleReadDto>();

             foreach (var u in  _ctx.BusShedules.Include(x => x.Busroute).ToList())
             {
               

                var busDto = new BusSheduleReadDto
                {
                    DepartureTime = u.DepartureTime,
                   
                    Busrooute = new BusRouteReadDto { BusrouteId = u.BusrouteId, IntermediateStops = u.Busroute.IntermediateStops},
                     Seats = u.Seats,
                     Cost = u.Cost,
                     ArrivalTime = u.ArrivalTime,
            };

            
                    shedules.Add(busDto);
             }

           

            return  shedules;
         }


    }
}
