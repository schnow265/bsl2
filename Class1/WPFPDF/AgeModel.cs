using System;

namespace WPFPDF
{
    public class AgeModel
    {
        #region Members

        private String date;
        private int age;

        #endregion

        #region SetAndForget aka Properties

        public string Date
        {
            get => date;
            set => date = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        #endregion
    }
}