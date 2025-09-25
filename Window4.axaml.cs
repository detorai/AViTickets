using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AVi.Models;
using AVi.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVi;

public partial class Window4 : Window
{
    private SearchParametrs _searchParameters;
    private TicketService _ticketService;
    private TicketDisplay _ticketDisplay;

    public Window4(SearchParametrs searchParametrs)
    {
        InitializeComponent();

        _ticketDisplay = new TicketDisplay();
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
        TicketsItemsControl.ItemsSource = tickets ?? new List<TicketDisplay>();
        
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
            var tarifWindow = new Window3();
            var selectedTariffId = await tarifWindow.ShowDialog<int>(this);
        }
    }
    private async void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (CurrentUser.IsLoggedIn && sender is Button button && button.DataContext is TicketDisplay ticket)
        {
            await BookTicket(ticket.TicketId, 1);
        }
        else
        {
            return;
        }
    }
    private async Task BookTicket(int ticketId, int tariffId)
    {
        using var transaction = await Hepler.Database.Database.BeginTransactionAsync();
        try
        {
            var ticket = await Hepler.Database.Tickets
                .FirstOrDefaultAsync(t => t.TicketId == ticketId) ?? new Ticket();


            ticket.TarifId = tariffId;
            ticket.BookerState = true;
            var booking = new Booker
            {
                BookerId = 1,
                UserId = CurrentUser.UserId.Value,
                TicketId = ticket.TicketId,
            };
            Hepler.Database.Bookers.Add(booking);
            await Hepler.Database.SaveChangesAsync();
            await transaction.CommitAsync();
            await LoadTickets();

        }
        catch
        {
            await transaction.RollbackAsync();
        }
    }
}