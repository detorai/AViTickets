using AVi.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
        public async Task<List<Ticket>> SearchTickets(SearchParametrs parametrs)
        {

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
                    .ToListAsync();
                return tickets;
            }
            catch
            {
                return new List<Ticket>();
            }
        }
    }
}
