using System.ComponentModel;
using System.Windows;

namespace TopCarrotMobile
{

    public class DetailsViewModel
    {
        private string _styleProperty = "srlvPluDetails";
        private string _DataTemplatView = "PluDetailsView";


        public DetailsViewModel()
        {
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string StyleProperty
        {
            get
            {
                return _styleProperty;
            }
            set
            {
                if (value != _styleProperty)
                {
                    _styleProperty = value;
                    NotifyPropertyChanged("StyleProperty");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Template
        {
            get
            {
                return _DataTemplatView;
            }
            set
            {
                _DataTemplatView = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// This is the method that controls the retirving and the display of data.
        /// </summary>
        public void LoadData()
        {
            this.IsDataLoaded = true;
        }



        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
