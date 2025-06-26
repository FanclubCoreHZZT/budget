using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BudgetApp.Data;
using BudgetApp.Models;

namespace BudgetApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUnitOfWork _uow;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            _uow = new UnitOfWork(new BudgetContext());
            LoginCommand = new RelayCommand(async () => await LoginAsync());
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }

        private async Task LoginAsync()
        {
            var user = await _uow.Users.FindByUsernameAsync(Username);
            if (user != null && user.PasswordHash == Password)
            {
                var main = new MainWindow();
                Application.Current.MainWindow = main;
                main.Show();
                foreach (Window w in Application.Current.Windows)
                {
                    if (w != main) w.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        private async Task RegisterAsync()
        {
            var existing = await _uow.Users.FindByUsernameAsync(Username);
            if (existing != null)
            {
                MessageBox.Show("User exists");
                return;
            }
            var user = new User { Username = Username, PasswordHash = Password };
            await _uow.Users.AddAsync(user);
            await _uow.CompleteAsync();
            MessageBox.Show("Registered");
        }
    }
}
