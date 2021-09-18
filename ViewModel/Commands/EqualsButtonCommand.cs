﻿using Calculator.Model;
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

        double result = 0;
        double firstNumberDouble = 0;
        double secondNumberDouble = 0;

        public void Execute(object parameter)
        {
            if(CalculatorVM.WasEqualsButtonUsed == false)
            {
                CalculatorVM.SecondNumber = parameter as string;
            }
            else
            {
                CalculatorVM.FirstNumber = parameter as string;
            }

            
            
            switch(Result.Operation)
            {
                case "+":
                    {
                        if (CalculatorVM.WasEqualsButtonUsed == false)
                        {
                            if (double.TryParse(Result.FirstNumber, out firstNumberDouble) == true && double.TryParse(Result.FullResult, out secondNumberDouble) == true)
                            {
                                result = firstNumberDouble + secondNumberDouble;
                                CalculatorVM.FullResult = result.ToString();
                                CalculatorVM.WasEqualsButtonUsed = true;
                            }
                        }
                        else
                        {
                            if (double.TryParse(Result.FullResult, out firstNumberDouble) == true)
                            {
                                CalculatorVM.FirstNumber = CalculatorVM.FullResult;
                                result = double.Parse(CalculatorVM.FirstNumber) + double.Parse(CalculatorVM.SecondNumber);
                                CalculatorVM.FullResult = result.ToString();
                            }
                        }
                        break;
                    }
                case "-":
                    {
                        if (CalculatorVM.WasEqualsButtonUsed == false)
                        {
                            if (double.TryParse(Result.FirstNumber, out firstNumberDouble) == true && double.TryParse(Result.FullResult, out secondNumberDouble) == true)
                            {
                                result = firstNumberDouble - secondNumberDouble;
                                CalculatorVM.FullResult = result.ToString();
                                CalculatorVM.WasEqualsButtonUsed = true;
                            }
                        }
                        else
                        {
                            if (double.TryParse(Result.FullResult, out firstNumberDouble) == true)
                            {
                                CalculatorVM.FirstNumber = CalculatorVM.FullResult;
                                result = double.Parse(CalculatorVM.FirstNumber) - double.Parse(CalculatorVM.SecondNumber);
                                CalculatorVM.FullResult = result.ToString();
                            }
                        }
                        break;
                    }
                case "/":
                    {
                        if (CalculatorVM.WasEqualsButtonUsed == false)
                        {
                            if (double.TryParse(Result.FirstNumber, out firstNumberDouble) == true && double.TryParse(Result.FullResult, out secondNumberDouble) == true)
                            {
                                result = firstNumberDouble / secondNumberDouble;
                                CalculatorVM.FullResult = result.ToString();
                                CalculatorVM.WasEqualsButtonUsed = true;
                            }
                        }
                        else
                        {
                            if (double.TryParse(Result.FullResult, out firstNumberDouble) == true)
                            {
                                CalculatorVM.FirstNumber = CalculatorVM.FullResult;
                                result = double.Parse(CalculatorVM.FirstNumber) / double.Parse(CalculatorVM.SecondNumber);
                                CalculatorVM.FullResult = result.ToString();
                            }
                        }
                        break;
                    }
                case "*":
                    {
                        if (CalculatorVM.WasEqualsButtonUsed == false)
                        {
                            if (double.TryParse(Result.FirstNumber, out firstNumberDouble) == true && double.TryParse(Result.FullResult, out secondNumberDouble) == true)
                            {
                                result = firstNumberDouble * secondNumberDouble;
                                CalculatorVM.FullResult = result.ToString();
                                CalculatorVM.WasEqualsButtonUsed = true;
                            }
                        }
                        else
                        {
                            if (double.TryParse(Result.FullResult, out firstNumberDouble) == true)
                            {
                                CalculatorVM.FirstNumber = CalculatorVM.FullResult;
                                result = double.Parse(CalculatorVM.FirstNumber) * double.Parse(CalculatorVM.SecondNumber);
                                CalculatorVM.FullResult = result.ToString();
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
                
            }
        }

        private void Calculate()
        {
            if (CalculatorVM.WasEqualsButtonUsed == false)
            {
                if (double.TryParse(Result.FirstNumber, out firstNumberDouble) == true && double.TryParse(Result.FullResult, out secondNumberDouble) == true)
                {
                    result = firstNumberDouble + secondNumberDouble;
                    CalculatorVM.FullResult = result.ToString();
                    CalculatorVM.WasEqualsButtonUsed = true;
                }
            }
            else
            {
                if (double.TryParse(Result.FullResult, out firstNumberDouble) == true)
                {
                    CalculatorVM.FirstNumber = CalculatorVM.FullResult;
                    result = double.Parse(CalculatorVM.FirstNumber) + double.Parse(CalculatorVM.SecondNumber);
                    CalculatorVM.FullResult = result.ToString();
                }
            }
        }
    }
}
