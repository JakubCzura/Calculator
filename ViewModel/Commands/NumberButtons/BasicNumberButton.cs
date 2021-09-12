using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands.NumberButtons
{
    public class BasicNumberButton : ICommand
    {
        public CalculatorVM CalculatorVM { get; set; }

        public BasicNumberButton(CalculatorVM calculatorVM)
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
            return true;
        }

        public virtual void Execute(object parameter)
        {
            CalculatorVM.FullResult += "0";
        }
    }
}
