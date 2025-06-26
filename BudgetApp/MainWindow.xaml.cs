using System.Windows;
using BudgetApp.ViewModels;

namespace BudgetApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
