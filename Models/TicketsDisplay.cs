using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVi.Models
{
    public class TicketDisplay
    {
        public int TicketId { get; set; }
        public string FlightNumber { get; set; } = string.Empty;
        public string Seat { get; set; } = string.Empty;

        // Цена
        public decimal Price { get; set; }

        // Авиакомпания
        public string AirlineName { get; set; } = string.Empty;
        public int AirlineId { get; set; }

        // Время и дата
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        // Города
        public string DepartureCity { get; set; } = string.Empty;
        public string ArrivalCity { get; set; } = string.Empty;

        // Аэропорты
        public string DepartureAirportName { get; set; } = string.Empty;
        public string ArrivalAirportName { get; set; } = string.Empty;
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }

        // Класс самолета
        public string FlightClassName { get; set; } = string.Empty;
        public int FlightClassId { get; set; }

        // Дополнительная информация
        public string AircraftName { get; set; } = string.Empty;
        public int AircraftId { get; set; }

        // Тариф
        public string TariffName { get; set; } = string.Empty;
        public int TariffId { get; set; }

        // ВЫЧИСЛЯЕМЫЕ СВОЙСТВА ДЛЯ XAML

        // Форматированная цена
        public string PriceFormatted => $"{Price}₽";

        // Форматированное время
        public string DepartureTimeFormatted => DepartureTime.ToString("HH:mm");
        public string ArrivalTimeFormatted => ArrivalTime.ToString("HH:mm");

        // Форматированная дата
        public string DepartureDateFormatted => DepartureTime.ToString("dd MMM, ddd").ToLower();
        public string ArrivalDateFormatted => ArrivalTime.ToString("dd MMM, ddd").ToLower();
        public string DepartureDateFull => DepartureTime.ToString("dd.MM.yyyy");
        public string ArrivalDateFull => ArrivalTime.ToString("dd.MM.yyyy");

        // Длительность полета
        public TimeSpan Duration => ArrivalTime - DepartureTime;
        public string DurationFormatted => $"{Duration.Hours}ч {Duration.Minutes}м";
        public string DurationShort => $"{Duration.Hours}ч";
    }
}
