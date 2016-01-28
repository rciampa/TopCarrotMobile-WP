using System.ComponentModel;

namespace TopCarrotMobile
{
    public class HereModel
    {
        private int _intPluId;
        private string _sPlu;
        private string _sName;
        private string _CropId;
        private string _sImageUri;
        private string _sDescription;
        private string _sVariety;
        private string _sSize;
        /// <summary>
        /// Public constructor
        /// </summary>
        public HereModel()
        {
        }

        /// <summary>
        /// The PluId or primary field on the SQL oData service
        /// </summary>
        public int PluId
        {
            get
            {
                return _intPluId;
            }
            set
            {
                _intPluId = value;
                NotifyPropertyChanged("PluId");
            }
        }
        /// <summary>
        /// The PLU (Price Look up Code)
        /// </summary>
        public string Plu
        {
            get
            {
                return _sPlu;
            }
            set
            {
                _sPlu = value;
                NotifyPropertyChanged("Plu");
            }
        }
        /// <summary>
        /// The name of the commodity
        /// </summary>
        public string Name
        {
            get
            {
                return _sName;
            }
            set
            {
                _sName = value;
                NotifyPropertyChanged("Name");
            }
        }
        /// <summary>
        /// The Top Carrot Crop ID
        /// </summary>
        public string CropId
        {
            get
            {
                return _CropId;
            }
            set
            {
                _CropId = value;
                NotifyPropertyChanged("CropId");
            }
        }
        /// <summary>
        /// The variety of the commodity
        /// </summary>
        public string Variety
        {
            get
            {
                return _sVariety;
            }
            set
            {
                _sVariety = value;
                NotifyPropertyChanged("Variety");
            }
        }
        /// <summary>
        /// The description of the commodity
        /// </summary>
        public string Description
        {
            get
            {
                return _sDescription;
            }
            set
            {
                _sDescription = value;
                NotifyPropertyChanged("Description");
            }
        }
        /// <summary>
        /// The size of the commodtiy
        /// </summary>
        public string Size
        {
            get
            {
                return _sSize;
            }
            set
            {
                _sSize = value;
                NotifyPropertyChanged("Size");
            }
        }
        /// <summary>
        /// The image Uri, can be local or remote
        /// </summary>
        public string ImageUri
        {
            get
            {
                return _sImageUri;
            }
            set
            {
                _sImageUri = value;
                NotifyPropertyChanged("ImageUri");
            }
        }




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
