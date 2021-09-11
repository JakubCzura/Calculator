using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands
{
    public class DivideByResultButtonCommand : ICommand
    {
        public DivideByResultButtonCommand(CalculatorVM calculatorVM)
        {
            CalculatorVM = calculatorVM;
        }

        CalculatorVM CalculatorVM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            string fullResult = parameter as string;
            decimal fullResultDecimal;
            if (fullResult != null && fullResult.Length > 0)
            {
                if (decimal.TryParse(parameter.ToString(), out fullResultDecimal) == true && fullResultDecimal!=0)
                {
                    return true;
                }
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (decimal.TryParse(parameter.ToString(), out decimal number) == true && number != 0)
            {
                number = 1 / number;
                CalculatorVM.FullResult = number.ToString();
            }
        }
    }
}
