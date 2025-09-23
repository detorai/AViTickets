using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AVi;

public partial class Window3 : Window
{
    public Window3()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Window4().Show();   
        Close();
    }
}