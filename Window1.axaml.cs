using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AVi;

public partial class Window1 : Window
{
    public Window1()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Window2().Show();
        Close();
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }
}