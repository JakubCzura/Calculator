using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands
{
    public class EqualsButtonCommand : ICommand
    {
        public EqualsButtonCommand(CalculatorVM calculatorVM, Result result)
        {
            CalculatorVM = calculatorVM;
            Result = result;
        }

        CalculatorVM CalculatorVM { get; set; }

        Result Result { get; set; }

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
            CalculatorVM.SecondNumber = parameter as string;

            double result = 0;
            double firstNumberDouble = 0;
            double secondNumberDouble = 0;
            
            switch(Result.Operation)
            {
                case "+":
                    {
                        if(double.TryParse(Result.FirstNumber, out firstNumberDouble) == true && double.TryParse(Result.FullResult, out secondNumberDouble) == true)
                        {
                            result = firstNumberDouble + secondNumberDouble;
                            CalculatorVM.FullResult = result.ToString();
                        }
                        break;
                    }
                case "-":
                    {
                        if (double.TryParse(Result.FirstNumber, out firstNumberDouble) == true && double.TryParse(Result.FullResult, out secondNumberDouble) == true)
                        {
                            result = firstNumberDouble - secondNumberDouble;
                            CalculatorVM.FullResult = result.ToString();
                        }
                        break;
                    }
                case "/":
                    {
                        if (double.TryParse(Result.FirstNumber, out firstNumberDouble) == true && double.TryParse(Result.FullResult, out secondNumberDouble) == true && secondNumberDouble!=0)
                        {
                            result = firstNumberDouble / secondNumberDouble;
                            CalculatorVM.FullResult = result.ToString();
                        }
                        break;
                    }
                case "*":
                    {
                        if (double.TryParse(Result.FirstNumber, out firstNumberDouble) == true && double.TryParse(Result.FullResult, out secondNumberDouble) == true)
                        {
                            result = firstNumberDouble * secondNumberDouble;
                            CalculatorVM.FullResult = result.ToString();
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
                
            }
        }
    }
}
