using System.Windows;
using BudgetApp.ViewModels;

namespace BudgetApp.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                vm.Password = ((System.Windows.Controls.PasswordBox)sender).Password;
            }
        }
    }
}
