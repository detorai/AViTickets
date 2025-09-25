using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AVi;

public partial class Window3 : Window
{
    public int SelectedTariffId { get; private set; }
    public Window3()
    {
        InitializeComponent();
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SelectedTariffId = 1;
        Close(SelectedTariffId);
        
    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SelectedTariffId = 2;
        Close(SelectedTariffId);
        
    }

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SelectedTariffId = 3;
        Close(SelectedTariffId);
        
    }

    private void Button_Click_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SelectedTariffId = 4;
        Close(SelectedTariffId);
    }
}