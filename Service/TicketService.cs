﻿using AVi.Models;
using Metsys.Bson;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVi.Service
{
    public class TicketService
    {
        public int GetAirportCityId(string cityName)
        {
            return Hepler.Database.Cities
                .Where(a => a.CityName == cityName)
                .Select(a => a.CityId)
                .FirstOrDefault();
        }
        public async Task<List<TicketDisplay>> SearchTickets(SearchParametrs parametrs)
        {

            var departureAirport = await Hepler.Database.Airports
            .FirstOrDefaultAsync(a => a.AirportId == GetAirportCityId(parametrs.FromCity));
            var arrivalAirport = await Hepler.Database.Airports
                .FirstOrDefaultAsync(a => a.AirportId == GetAirportCityId(parametrs.ToCity));
            try
            {
                var tickets = await Hepler.Database.Tickets
                    .Include(t => t.DepAirport)
                    .Include(t => t.ArAirport)
                    .Include(t => t.Airlines)
                    .Include(t => t.Class)
                    .Include(t => t.Tarif)
                    .Where(t =>
                        t.DepAirport.AirportCity == GetAirportCityId(parametrs.FromCity) &&
                        t.ArAirport.AirportCity == GetAirportCityId(parametrs.ToCity) &&
                        t.TimeOut.Date == parametrs.DepartureDate.Date &&
                        t.Class.ClassName == parametrs.FlightClass &&
                        t.BookerState != true)
                    .Select(t => new TicketDisplay
                    {
                        TicketId = t.TicketId,
                        Price = t.Cost + t.Tarif.TarifCost,
                        AirlineName = t.Airlines.AirlinesName,
                        AirlineId = t.Airlines.AirlinesId,
                        DepartureTime = t.TimeOut,
                        ArrivalTime = t.TimeIn,
                        DepartureCity = parametrs.FromCity,
                        ArrivalCity = parametrs.ToCity,
                        DepartureAirportName = departureAirport.AirportName,
                        ArrivalAirportName = arrivalAirport.AirportName,
                        DepartureAirportId = t.DepAirportId,
                        ArrivalAirportId = t.ArAirportId,
                        FlightClassName = t.Class.ClassName,
                        FlightClassId = t.ClassId,
                        AircraftName = t.Aircraft.AircraftsName,
                        AircraftId = t.AircraftId,
                        TariffId = t.TarifId ?? 0
                    })
                    .ToListAsync();
                return tickets;
            }
            catch
            {
                return new List<TicketDisplay>();
            }
        }
    }
}
