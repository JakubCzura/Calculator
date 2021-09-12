using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands
{
    public class NumberButtonCommand : ICommand
    {
        public NumberButtonCommand(CalculatorVM calculatorVM)
        {
            CalculatorVM = calculatorVM;
        }

        public CalculatorVM CalculatorVM { get; set; }

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
            CalculatorVM.FullResult += "22";
        }
    }
}
