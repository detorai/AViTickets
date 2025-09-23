using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AVi;

public partial class Window4 : Window
{
    public Window4()
    {
        InitializeComponent();
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