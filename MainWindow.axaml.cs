using Avalonia.Controls;
using AVi.Models;
using AVi.Service;
using System;

namespace AVi
{
    public partial class MainWindow : Window
    {
        private TicketService _ticketService;
        public MainWindow()
        { 
            InitializeComponent();
            _ticketService = new TicketService();  
        }

        private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            var dialog = new Window6();
            var result = await dialog.ShowDialog<string>(this);

            if (!string.IsNullOrEmpty(result))
            {
                ClassSelector.Text = result;
            }
        }

       

        private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            new Window3().Show();
            Close();
        }

        private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var departureAirportId = _ticketService.GetAirportCityId(FromTextBox.Text);
            var arrivalAirportId = _ticketService.GetAirportCityId(OutTextBox.Text);
            if (!DateTime.TryParse(DevTimeTextBox.Text, out var departureDate))
            {
                return;
            }

            if (!DateTime.TryParse(ArTimeTextBox.Text, out var returnDate))
            {
                return;
            }
            var searchParams = new SearchParametrs
            {
                FromCity = FromTextBox.Text,
                ToCity = OutTextBox.Text,
                DepartureDate = departureDate ,
                ReturnDate = returnDate,
                FlightClass = ClassSelector.Text
            };
            var resultsWindows = new Window4(searchParams);
            resultsWindows.Show();
            Close();
        }
    }
}