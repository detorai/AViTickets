using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AVi.Models;
using AVi.Service;
using System;

namespace AVi;

public partial class Window7 : Window
{
    private TicketService _ticketService;
    public Window7()
    {
        InitializeComponent();
        _ticketService = new TicketService();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Window5().ShowDialog(this);
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Window6().ShowDialog(this);
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
            DepartureDate = departureDate,
            ReturnDate = returnDate
        };
        var resultsWindows = new Window4(searchParams);
        resultsWindows.Show();
        Close();
    }
}