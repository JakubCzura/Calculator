using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands.MenuCommands
{
    public class ChangeThemeCommand : ICommand
    {
        public ChangeThemeCommand(string themeName)
        {
            ThemeName = themeName;
        }

        string ThemeName { get; set; } 

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
       
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {                   
            try
            {
                App.Current.Resources.Clear();
                App.Current.Resources.Source = new Uri($"/Themes/{ThemeName}.xaml", UriKind.Relative);
            }
            catch (Exception exception)
            {
                App.Current.Resources.Source = new Uri(@"/Themes/Standard.xaml", UriKind.Relative);
                MessageBox.Show(exception.Message);
            }
        }
    }
}
