using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands
{
    public class PercentButtonCommand : ICommand
    {
        public PercentButtonCommand(CalculatorVM calculatorVM)
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

            if (fullResult != null && fullResult.Length > 0)
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
            fullResultDouble /= 100;
            CalculatorVM.FullResult = fullResultDouble.ToString();
        }
    }
}
