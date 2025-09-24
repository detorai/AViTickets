using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AVi.Models;
using AVi.Service;
using System.Linq;
using System.Threading.Tasks;

namespace AVi;

public partial class Window4 : Window
{
    private SearchParametrs _searchParameters;
    private TicketService _ticketService;
    
    public Window4(SearchParametrs searchParametrs)
    {
        InitializeComponent();
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

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Window3().Show();
        Close();
    }
}