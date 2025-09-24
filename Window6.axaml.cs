using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AVi;

public partial class Window6 : Window
{
    public string SelectedClass { get; private set; } = string.Empty;
    public Window6()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            
            var textBlock = button.Content as TextBlock;
            if (textBlock != null)
            {
                SelectedClass = textBlock.Text;
                Close(SelectedClass);
            }
        }
    }
}