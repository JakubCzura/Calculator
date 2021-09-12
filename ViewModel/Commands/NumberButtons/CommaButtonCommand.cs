using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands.NumberButtons
{
    public class CommaButtonCommand : BasicNumberButton, ICommand
    {
        public CommaButtonCommand(CalculatorVM calculatorVM) : base(calculatorVM)
        {
        }

        public override bool CanExecute(object parameter)
        {
            if (string.IsNullOrWhiteSpace(CalculatorVM.FullResult) == true || CalculatorVM.FullResult.Contains(',') == true)
            {
                return false;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            CalculatorVM.FullResult += ",";
        }
    }
}
