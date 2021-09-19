using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands
{
    public class DivideButtonCommand : ICommand
    {
        public DivideButtonCommand(CalculatorVM calculatorVM)
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
                if (double.TryParse(parameter.ToString(), out fullResultDouble) == true && double.IsInfinity(fullResultDouble) == false)
                {
                    return true;
                }
            }
            return false;
        }

        public void Execute(object parameter)
        {
            CalculatorVM.FirstNumber = parameter as string;
            CalculatorVM.Operation = "/";
            CalculatorVM.FullResult = string.Empty;
            CalculatorVM.SecondNumber = string.Empty;
            CalculatorVM.WasEqualsButtonUsed = false;
        }
    }
}
