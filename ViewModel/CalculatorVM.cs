using Calculator.Model;
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
        private Result Result = new Result();

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
        public PlusMinusButtonCommand PlusMinusButtonCommand { get; set; }
        public PowerButtonCommand PowerButtonCommand { get; set; }
        public SquareRootButtonCommand SquareRootButtonCommand { get; set; }
        public PercentButtonCommand PercentButtonCommand { get; set; }
        public CeButtonCommand CeButtonCommand { get; set; }
        public CButtonCommand CButtonCommand { get; set; }
        public MultiplyButtonCommand MultiplyButtonCommand { get; set; }

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
            PlusMinusButtonCommand = new PlusMinusButtonCommand(this);
            PowerButtonCommand = new PowerButtonCommand(this);
            SquareRootButtonCommand = new SquareRootButtonCommand(this);
            PercentButtonCommand = new PercentButtonCommand(this);
            CeButtonCommand = new CeButtonCommand(this);
            CButtonCommand = new CButtonCommand(this);
            MultiplyButtonCommand = new MultiplyButtonCommand(this, Result);
        }

        //public Result Result
        //{
        //    get { return result; }
        //    set
        //    {
        //        Result = value;
        //        OnPropertyChanged("Result");
        //    }
        //}

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
