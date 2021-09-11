using Calculator.Model;
using Calculator.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Calculator.ViewModel
{
    public class CalculatorVM : INotifyPropertyChanged
    {
        private Result result = new Result { FullResult = "1231321" };
        public NumberButtonCommand NumberButtonCommand { get; set; }
        public BackButtonCommand BackButtonCommand { get; set; }
        public CalculatorVM()
        {
            NumberButtonCommand = new NumberButtonCommand(this);
            BackButtonCommand = new BackButtonCommand(this);
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
