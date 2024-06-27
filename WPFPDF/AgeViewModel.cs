using BSWPFLib;

namespace WPFPDF
{
    public class AgeViewModel : BS2NotifyPropertyBase
    {
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

        #endregion
    }
}