using System;
using System.Globalization;
using System.Windows.Input;
using BSWPFLib;

namespace WPFPDF
{
    public class AgeViewModel : BS2NotifyPropertyBase
    {
        public AgeViewModel()
        {
            _model.Date = "20.11.1999";
            CalcAgeCmd = new BS2Command(OnCalcAge);
        }

        #region Member

        private AgeModel _model = new AgeModel();

        #endregion

        #region Properties

        public string Date
        {
            get => _model.Date;
            set
            {
                _model.Date = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get => _model.Age;
            set
            {
                _model.Age = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalcAgeCmd { get; set; }

        #endregion


        #region Events

        public void OnCalcAge(object param)
        {
            Age = (DateTime.Now - DateTime.Parse(Date)).Days / 365;
        }

        #endregion
    }
}