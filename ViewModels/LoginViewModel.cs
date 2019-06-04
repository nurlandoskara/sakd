using System.Linq;
using System.Windows.Input;
using SAKD.Views;

namespace SAKD.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        private string _error;
        public string Username { get; set; }
        public string Password { get; set; }

        public string Error
        {
            get => _error;
            set => SetProperty(ref _error, value);
        }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            Username = "manager";
            Password = "manager";
            LoginCommand = new Command(Login, CanExecuteCommand);
        }

        public void Login(object parameter)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Error = "Логин немесе пароль дұрыс емес";
                return;
            }
            
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
