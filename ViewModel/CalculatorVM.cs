﻿using Calculator.Model;
using Calculator.ViewModel.Commands;
using Calculator.ViewModel.Commands.NumberButtons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Calculator.ViewModel
{
    public class CalculatorVM : INotifyPropertyChanged
    {
        private Result result = new Result { FullResult = "1231321" };

        public NumberButtonCommand ZeroButtonCommand { get; set; }
        public NumberButtonCommand OneButtonCommand { get; set; }
        public NumberButtonCommand TwoButtonCommand { get; set; }
        public NumberButtonCommand ThreeButtonCommand { get; set; }
        public NumberButtonCommand FourButtonCommand { get; set; }
        public NumberButtonCommand FiveButtonCommand { get; set; }
        public NumberButtonCommand SixButtonCommand { get; set; }
        public NumberButtonCommand SevenButtonCommand { get; set; }
        public NumberButtonCommand EightButtonCommand { get; set; }
        public NumberButtonCommand NineButtonCommand { get; set; }
        public CommaButtonCommand CommaButtonCommand { get; set; }
        public BackButtonCommand BackButtonCommand { get; set; }
        public DivideByResultButtonCommand DivideByResultButtonCommand { get; set; }

        public CalculatorVM()
        {
            ZeroButtonCommand = new NumberButtonCommand(this, "0");
            OneButtonCommand = new NumberButtonCommand(this, "1");
            TwoButtonCommand = new NumberButtonCommand(this, "2");
            ThreeButtonCommand = new NumberButtonCommand(this, "3");
            FourButtonCommand = new NumberButtonCommand(this, "4");
            FiveButtonCommand = new NumberButtonCommand(this, "5");
            SixButtonCommand = new NumberButtonCommand(this, "6");
            SevenButtonCommand = new NumberButtonCommand(this, "7");
            EightButtonCommand = new NumberButtonCommand(this, "8");
            NineButtonCommand = new NumberButtonCommand(this, "9");
            CommaButtonCommand = new CommaButtonCommand(this);
            BackButtonCommand = new BackButtonCommand(this);
            DivideByResultButtonCommand = new DivideByResultButtonCommand(this);
        }

        public Result Result
        {
            get { return result; }
            set
            {
                Result = value;
                OnPropertyChanged("Result");
            }
        }

        private string fullResult;

        public string FullResult
        {
            get { return fullResult; }
            set
            {
                fullResult = value;
                OnPropertyChanged("FullResult");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
