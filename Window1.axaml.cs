using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AVi.Models;
using AVi.Service;
using System.Threading.Tasks;

namespace AVi;

public partial class Window1 : Window
{
    private UserService _userService;
    public Window1()
    {
        InitializeComponent();
        _userService = new UserService();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Window2().ShowDialog(this);
        
    }

    private async void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var phone = PhoneTextBox.Text;
        var password = PasswordTextBox.Text;

        if (phone == null || password == null)
        {
            return;
        }
        try
        {
            var user = await _userService.LoginUser(phone, password);

            if (user != null)
            {
                CurrentUser.Login(user.UserId);
                new MainWindow().Show();
                Close();
            }
        }
        catch
        {}
        
    }
}