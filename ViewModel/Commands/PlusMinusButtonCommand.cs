using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands
{
    public class PlusMinusButtonCommand : ICommand
    {
        public PlusMinusButtonCommand(CalculatorVM calculatorVM)
        {
            CalculatorVM = calculatorVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        CalculatorVM CalculatorVM { get; set; }

        public bool CanExecute(object parameter)
        {
            string fullResult = parameter as string;
            decimal fullResultDecimal;
            if (fullResult != null && fullResult.Length > 0)
            {
                if (decimal.TryParse(parameter.ToString(), out fullResultDecimal) == true && fullResultDecimal != 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if(CalculatorVM.FullResult[0] == '-')
            {
                CalculatorVM.FullResult = CalculatorVM.FullResult.Substring(1);
            }
            else
            {
                CalculatorVM.FullResult = $"-{CalculatorVM.FullResult}";
            }
        }
    }
}
