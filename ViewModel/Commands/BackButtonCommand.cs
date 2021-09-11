using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands
{
    public class BackButtonCommand : ICommand
    {
        public CalculatorVM CalculatorVM { get; set; }

        public BackButtonCommand(CalculatorVM calculatorVM)
        {
            CalculatorVM = calculatorVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            string fullResult = parameter as string;
            if (fullResult != null && fullResult.Length>0)
            {
                return true;
            }               
            return false;
        }

        public void Execute(object parameter)
        {
            CalculatorVM.FullResult = CalculatorVM.FullResult.Remove(CalculatorVM.FullResult.Length-1);
        }
    }
}
