using System.Windows;
using System.Windows.Input;
using BudgetApp.Helpers;

namespace BudgetApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly UndoRedoManager _undoRedo = new();
        public ICommand SetLightThemeCommand { get; }
        public ICommand SetDarkThemeCommand { get; }
        public ICommand SetEnglishCommand { get; }
        public ICommand SetSpanishCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand RedoCommand { get; }

        public object? CurrentView { get; set; }

        private string _currentTheme = "Resources/Themes/LightTheme.xaml";
        private string _currentLanguage = "Resources/StringResources.xaml";

        public MainViewModel()
        {
            SetLightThemeCommand = new RelayCommand(() => SetTheme("Resources/Themes/LightTheme.xaml"));
            SetDarkThemeCommand = new RelayCommand(() => SetTheme("Resources/Themes/DarkTheme.xaml"));
            SetEnglishCommand = new RelayCommand(() => SetLanguage("Resources/StringResources.xaml"));
            SetSpanishCommand = new RelayCommand(() => SetLanguage("Resources/StringResources.es.xaml"));
            UndoCommand = new RelayCommand(() => _undoRedo.Undo());
            RedoCommand = new RelayCommand(() => _undoRedo.Redo());
        }

        private void SetTheme(string resource)
        {
            var previous = _currentTheme;
            _undoRedo.Do(
                redo: () => {
                    ApplyTheme(resource);
                    _currentTheme = resource;
                },
                undo: () => {
                    ApplyTheme(previous);
                    _currentTheme = previous;
                });
        }

        private void SetLanguage(string resource)
        {
            var previous = _currentLanguage;
            _undoRedo.Do(
                redo: () => {
                    ApplyLanguage(resource);
                    _currentLanguage = resource;
                },
                undo: () => {
                    ApplyLanguage(previous);
                    _currentLanguage = previous;
                });
        }

        private void ApplyTheme(string resource)
        {
            var dict = new ResourceDictionary { Source = new System.Uri(resource, System.UriKind.Relative) };
            var app = Application.Current;
            app.Resources.MergedDictionaries[1] = dict;
        }

        private void ApplyLanguage(string resource)
        {
            var dict = new ResourceDictionary { Source = new System.Uri(resource, System.UriKind.Relative) };
            var app = Application.Current;
            app.Resources.MergedDictionaries[0] = dict;
        }
    }
}
