using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands.NumberButtons
{
    public class NumberButtonCommand : BasicNumberButton, ICommand
    {
        public NumberButtonCommand(CalculatorVM calculatorVM, string number = "0") : base(calculatorVM)
        {
            Number = number;
        }

        string Number { get; set; }

        public override void Execute(object parameter)
        {
            CalculatorVM.FullResult += Number;
        }
    }
}
