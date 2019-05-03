using System.Linq;
using System.Windows.Input;

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
            Username = "apetrova";
            Password = "asdfgh12";
            LoginCommand = new Command(Login, CanExecuteCommand);
        }

        public void Login(object parameter)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Error = "Логин немесе пароль дұрыс емес";
                return;
            }

            using (var db = new ModelContainer())
            {
                var user = db.Users.FirstOrDefault(x => x.Username == Username && x.Password == Password);
                if (user == null)
                {
                    Error = "Логин немесе пароль дұрыс емес";
                    return;
                }
            }
        }
    }
}
