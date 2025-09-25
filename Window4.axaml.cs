using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AVi.Models;
using AVi.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AVi;

public partial class Window4 : Window
{
    private SearchParametrs _searchParameters;
    private TicketService _ticketService;
    private int _selectedTicketId;
    private int _selectedTariffId;

    public Window4(SearchParametrs searchParametrs)
    {

        _searchParameters = searchParametrs;
        _ticketService = new TicketService();

        InitializeWindow(); 
    }

    private async void InitializeWindow()
    {
        await LoadTickets();
    }
    private async Task LoadTickets()
    {
        var tickets = await _ticketService.SearchTickets(_searchParameters);

        if (tickets != null && tickets.Any())
        {
            TicketsItemsControl.ItemsSource = tickets;
            TicketsItemsControl.IsVisible = true;
        }
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }

    private async void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is TicketDisplay ticket)
        {
            _selectedTicketId = ticket.TicketId;
            var tarifWindow = new Window3();
            var selectedTariffId = await tarifWindow.ShowDialog<int>(this);
            _selectedTariffId = selectedTariffId;
        }
    }

    private async Task BookTicket(int ticketId, int tariffId)
    {
        try
        {
            var ticket = await Hepler.Database.Tickets
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);

            if (ticket != null)
            {
                ticket.TarifId = tariffId;
                ticket.BookerState = true;
                var booking = new Booker
                {
                    UserId = CurrentUser.UserId.Value,
                    TicketId = ticketId,
                };
                Hepler.Database.Bookers.Add(booking);
                await Hepler.Database.SaveChangesAsync();
            }
        }
        catch {
        }
    }

    private async void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (CurrentUser.IsLoggedIn)
        {
            await BookTicket(_selectedTicketId, _selectedTariffId);
        }
        else
        {
            return;
        }
    }
}