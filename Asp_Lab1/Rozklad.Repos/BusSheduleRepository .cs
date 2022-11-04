using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Rozklad.Core;
using Rozklad.Repos.Dto;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
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

  

        public async Task<BusShedule> CreateBusSheduleAsync(DateTime Departuretime , BusRoute? busRoute,MapsRoute? mapsRoute, int? seats, Carrier? carrier, Status? status, DateTime Arrivaltime, float cost)
        {
          var newShedule = new BusShedule
            {
                DepartureTime = Departuretime,
                //mapsRoute = mapsRoute,
                Busroute = busRoute,             
                Seats = seats,
                carrier = carrier,
              status = status,
                ArrivalTime = Arrivaltime,
                Cost = cost,
                buyTicketId=1
          };

    
            //await shedules.Add(newShedule);
            //await _ctx.AddAsync(newShedule);
            //return await _ctx.BusShedules.FirstAsync(x => x.DepartureTime == Departuretime );
        
           _ctx.BusShedules.Add(newShedule);
            await _ctx.SaveChangesAsync();
            return await _ctx.BusShedules.FirstAsync(x => x.DepartureTime == Departuretime);
        }


       /* public async Task DeleteBusSheduleAsync(string id)
        {
            var shedule = _ctx.BusShedules.Find(id);

            if ((await userManager.GetRolesAsync(user)).Any())
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            }
            await userManager.DeleteAsync(user);
        }*/


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

       /* public async Task<UserReadDto> GetUsersAsync(string id)
        {
            var u = await _ctx.Users.FirstAsync(x => x.Id == id);


            var userDto = new UserReadDto
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                IsConfirmed = u.EmailConfirmed,
                Roles = new List<IdentityRole>()
            };

            foreach (var role in await userManager.GetRolesAsync(u))
            {
                userDto.Roles.Add(await _ctx.Roles.FirstAsync(x => x.Name.ToLower() == role.ToLower()));

            }
            return userDto;
        }*/


    }
}
