using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rozklad.Core;
using Rozklad.Repos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

             foreach (var u in  _ctx.BusShedules.Include(x => x.Busroute).Include(x => x.carrier).Include(x=>x.status).ToList())
             {
               

                var busDto = new BusSheduleReadDto
                {
                    DepartureTime = u.DepartureTime,
                   
                    Busrooute = new BusRouteReadDto { BusrouteId = u.BusrouteId, PlaceOfDeparture = u.Busroute.PlaceOfDeparture, IntermediateStops = u.Busroute.IntermediateStops, PlaceOfArrival = u.Busroute.PlaceOfArrival},
                     Seats = u.Seats,
                     carier = new CarrierReadDto {carrierId = u.carrierId , Name = u.carrier.Name, Transport = u.carrier.Transport },

                         Cost = u.Cost,
                     ArrivalTime = u.ArrivalTime,
                     status = new StatusReadDto { statusId =u.statusId , StatusValue = u.status.StatusValue}
            };

            
                    shedules.Add(busDto);
             }

           

            return  shedules;
         }


    }
}
