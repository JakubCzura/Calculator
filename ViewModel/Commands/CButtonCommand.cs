using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands
{
    public class CButtonCommand : ICommand
    {
        public CButtonCommand(CalculatorVM calculatorVM)
        {
            CalculatorVM = calculatorVM;
        }

        CalculatorVM CalculatorVM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        double fullResultDouble = 0;

        public bool CanExecute(object parameter)
        {
            string fullResult = parameter as string;

            if (string.IsNullOrWhiteSpace(fullResult) == false && fullResult.Length > 0)
            {
                if (double.TryParse(parameter.ToString(), out fullResultDouble) == true)
                {
                    return true;
                }
            }
            return false;
        }

        public void Execute(object parameter)
        {
            CalculatorVM.FirstNumber = string.Empty;
            CalculatorVM.SecondNumber = string.Empty;
            CalculatorVM.Operation = string.Empty;
            CalculatorVM.FullResult = string.Empty;
        }
    }
}
