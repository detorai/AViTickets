using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AVi.Service;
using System.Threading.Tasks;

namespace AVi;

public partial class Window2 : Window
{
    private UserService _userService;
    public Window2()
    {
        InitializeComponent();
        _userService = new UserService();  
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var phone = PhoneTextBox.Text;
        var password =  PasswordTextBox.Text;
        var passwordRe =  PasswordReTextBox.Text;

        if (phone == null || password == null || passwordRe == null || passwordRe != password)
        {
            return;
        }
        var result = await _userService.RegisterUser(phone, password);

        if (result)
        {
            new Window7().Show();
            Close();
        }
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Window1().Show();
        Close();
    }
}