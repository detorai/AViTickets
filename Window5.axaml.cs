using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AVi.Models;

namespace AVi;

public partial class Window5 : Window
{
    public Window5()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Window3().Show();
        Close();
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CurrentUser.Logout();
        new MainWindow().Show();
        Close();
    }
}