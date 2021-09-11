using Calculator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Calculator.ViewModel
{
    public class CalculatorVM : INotifyPropertyChanged
    {
        private Result result;
     
        public Result Result
        {
            get { return result; }
            set
            {
                Result = value;
                OnPropertyChanged("Result");
            }
        }

        private decimal fullResult;

        public decimal FullResult
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
