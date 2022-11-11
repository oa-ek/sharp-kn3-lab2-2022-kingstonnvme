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
using System.Threading;
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

        public async Task<BuyTicket> CreateTicketAsync(string? buyerName, int numTicket, string? Nomertel, int allprice, Card? card)
        {
            var newBuy = new BuyTicket
            {
               BuyerName = buyerName,
               numTicket = numTicket,
                NomerTel = Nomertel,
                AllPrice = allprice,
                card = card

            };


            //await shedules.Add(newShedule);
            //await _ctx.AddAsync(newShedule);
            //return await _ctx.BusShedules.FirstAsync(x => x.DepartureTime == Departuretime );

            _ctx.BuyTickets.Add(newBuy);
            await _ctx.SaveChangesAsync();
            return await _ctx.BuyTickets.FirstAsync(x => x.NomerTel == Nomertel);
        }
        public async Task DeleteBusSheduleAsync(int? id)
        {
            var shedule =  _ctx.BusShedules.Find(id);

       
             _ctx.BusShedules.Remove(shedule);
            await _ctx.SaveChangesAsync();
        }
        public async Task DeleteTicketAsync(int? id)
        {
            var ticket = _ctx.BuyTickets.Find(id);


            _ctx.BuyTickets.Remove(ticket);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<BusSheduleReadDto>> GetBusSheduleAsync()
         {
         

            var shedules = new List<BusSheduleReadDto>();

             foreach (var u in  _ctx.BusShedules.Include(x => x.Busroute).Include(x => x.carrier).Include(x=>x.status).Include(x=>x.buyTicket).ToList())
             {
               

                var busDto = new BusSheduleReadDto
                {
                    Id = u.Id,
                    DepartureTime = u.DepartureTime,
                   
                    Busrooute = new BusRouteReadDto { BusrouteId = u.BusrouteId, PlaceOfDeparture = u.Busroute.PlaceOfDeparture, IntermediateStops = u.Busroute.IntermediateStops, PlaceOfArrival = u.Busroute.PlaceOfArrival},
                     Seats = u.Seats,
                     carier = new CarrierReadDto {carrierId = u.carrierId , Name = u.carrier.Name, Transport = u.carrier.Transport },

                         Cost = u.Cost,
                     ArrivalTime = u.ArrivalTime,
                     status = new StatusReadDto { statusId =u.statusId , StatusValue = u.status.StatusValue},


                      ticket = new TicketReadDto { buyTicketId = u.buyTicketId, BuyerName = u.buyTicket.BuyerName, numTicket= u.buyTicket.numTicket, NomerTel = u.buyTicket.NomerTel, AllPrice = u.buyTicket.AllPrice}

                };


        shedules.Add(busDto);
             }

           

            return  shedules;
         }

        public async Task<IEnumerable<TicketReadDto>> GetTicketAsync()
        {
            var tickets = new List<TicketReadDto>();

            foreach (var u in _ctx.BuyTickets.ToList())
            {
                var tikDto = new TicketReadDto
                {
                    buyTicketId = u.buyTicketId,
                    BuyerName = u.BuyerName,
                    numTicket = u.numTicket,
                    NomerTel = u.NomerTel,
                    AllPrice = u.AllPrice            
               };
                tickets.Add(tikDto);
            }
            return tickets;
        }

        public async Task<BusSheduleReadDto> GetBusSheduleAsync(int? id)
        {
            var u = await _ctx.BusShedules.FirstAsync(x => x.Id == id);


            var busDto = new BusSheduleReadDto
            {
                Id = u.Id,
                DepartureTime = u.DepartureTime,

                // Busrooute = new BusRouteReadDto { BusrouteId = u.BusrouteId, PlaceOfDeparture = u.Busroute.PlaceOfDeparture, IntermediateStops = u.Busroute.IntermediateStops, PlaceOfArrival = u.Busroute.PlaceOfArrival },
                Seats = u.Seats,
                // carier = new CarrierReadDto { carrierId = u.carrierId, Name = u.carrier.Name, Transport = u.carrier.Transport },

                Cost = u.Cost,
                ArrivalTime = u.ArrivalTime,
                // status = new StatusReadDto { statusId = u.statusId, StatusValue = u.status.StatusValue }
            };
            return busDto;
        }

        public async Task<TicketReadDto> GetTicketAsync(int? id)
        {
            var u = await _ctx.BuyTickets.FirstAsync(x => x.buyTicketId == id);

            
            var tikDto = new TicketReadDto
            {
                buyTicketId = u.buyTicketId,
                BuyerName = u.BuyerName,
                numTicket =u.numTicket,
                NomerTel = u.NomerTel,
                AllPrice = u.AllPrice
               
            };
            return tikDto;
        }

        public async Task<BusSheduleReadDto> GetBusSheduleEditAsync(int? id)
        {
            var u = await _ctx.BusShedules.Include(x => x.Busroute).Include(x => x.carrier).Include(x => x.status).FirstAsync(x => x.Id == id);


            var busDto = new BusSheduleReadDto
            {
                Id = u.Id,
                DepartureTime = u.DepartureTime,

                 Busrooute = new BusRouteReadDto { BusrouteId = u.Id, PlaceOfDeparture = u.Busroute.PlaceOfDeparture, IntermediateStops = u.Busroute.IntermediateStops, PlaceOfArrival = u.Busroute.PlaceOfArrival },
                Seats = u.Seats,
                 carier = new CarrierReadDto { carrierId = u.Id, Name = u.carrier.Name, Transport = u.carrier.Transport },

                Cost = u.Cost,
                ArrivalTime = u.ArrivalTime,
                 status = new StatusReadDto { statusId = u.Id, StatusValue = u.status.StatusValue }
            };
            return busDto;
        }

        public async Task UpdateAsync(BusSheduleReadDto model)
        {
            var busShedule = await _ctx.BusShedules.Include(x => x.Busroute).Include(x => x.carrier).Include(x => x.status).FirstAsync(x => x.Id == model.Id);


            if (busShedule.DepartureTime != model.DepartureTime)
            {
                busShedule.DepartureTime = model.DepartureTime;
            }
            if (busShedule.Busroute.PlaceOfDeparture != model.Busrooute.PlaceOfDeparture)
            {
                busShedule.Busroute.PlaceOfDeparture = model.Busrooute.PlaceOfDeparture;
            }
            if (busShedule.Busroute.IntermediateStops != model.Busrooute.IntermediateStops)
            {
                busShedule.Busroute.IntermediateStops = model.Busrooute.IntermediateStops;
            }
            if (busShedule.Busroute.PlaceOfArrival != model.Busrooute.PlaceOfArrival)
            {
                busShedule.Busroute.PlaceOfArrival = model.Busrooute.PlaceOfArrival;
            }
            if (busShedule.Seats != model.Seats)
            {
                busShedule.Seats = model.Seats;
            }
            if (busShedule.carrier.Transport != model.carier.Transport)
            {
                busShedule.carrier.Transport = model.carier.Transport;
            }
            if (busShedule.carrier.Name != model.carier.Name)
            {
                busShedule.carrier.Name = model.carier.Name;
            }
            if (busShedule.status.StatusValue != model.status.StatusValue)
            {
                busShedule.status.StatusValue = model.status.StatusValue;
            }
            if (busShedule.ArrivalTime != model.ArrivalTime)
            {
                busShedule.ArrivalTime = model.ArrivalTime;
            }
            if (busShedule.Cost != model.Cost)
            {
                busShedule.Cost = model.Cost;
            }

            _ctx.BusShedules.Update(busShedule);
            await _ctx.SaveChangesAsync();
        }


    }
}
