using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Calculator.Themes;

namespace Calculator.ViewModel.Commands.MenuCommands
{
    public class ChangeThemeCommand : ICommand
    {
        public ChangeThemeCommand(EnumThemes.Themes theme)
        {
            Theme = theme;
        }

        EnumThemes.Themes Theme { get; set; }
        
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
                App.Current.Resources.Source = new Uri($"/Themes/{Theme}.xaml", UriKind.Relative);
            }
            catch (Exception exception)
            {              
                MessageBox.Show(exception.Message, "Zrestartuj aplikację");
            }
        }
    }
}
