using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AVi;

public partial class Window2 : Window
{
    public Window2()
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
        new Window1().Show();
        Close();
    }
}