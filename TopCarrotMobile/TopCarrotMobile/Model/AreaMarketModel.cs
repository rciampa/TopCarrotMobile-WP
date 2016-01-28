using System.ComponentModel;
using System.Device.Location;

namespace TopCarrotMobile
{
    public class AreaMarketModel : INotifyPropertyChanged
    {
        private int _intId;
        private int _intMarketId;
        private string _sName;
        private string _sImageUri;
        private string _sDescription;
        private string _sSpecialty;
        private string _sSize;
        private string _sLongitude;
        private string _sLatidude;
        private GeoCoordinate _GpsLocation;
        private string _WebUrl;
        private string _Email;
        private string _Phone;

        public AreaMarketModel()
        {
        }

        /// <summary>
        /// Table Id of primary field in local db
        /// </summary>
        public int Id
        {
            get
            {
                return _intId;
            }
            set
            {
                _intId = value;
                NotifyPropertyChanged("Id");
            }
        }
        /// <summary>
        /// The Farmer Market Id or primary field on the SQL oData service
        /// </summary>
        public int FarmerMarketOdataId
        {
            get
            {
                return _intMarketId;
            }
            set
            {
                _intMarketId = value;
                NotifyPropertyChanged("FarmerMarketOdataId");
            }
        }
        /// <summary>
        /// The name of the famers market
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
        /// The specialty of the farmers market
        /// </summary>
        public string Specialty
        {
            get
            {
                return _sSpecialty;
            }
            set
            {
                _sSpecialty = value;
                NotifyPropertyChanged("Specialty");
            }
        }
        /// <summary>
        /// The description of the farmers market
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
        /// The size of the farmers market
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
        /// <summary>
        /// The GeoCordinate infomration of the farmers market
        /// </summary>
        //public double GpsLocationLat
        //{
        //    get
        //    {
        //        return _GpsLocation.Latitude;
        //    }
        //    set
        //    {
        //        _GpsLocation.Latitude = value;
        //        NotifyPropertyChanged("GpsLocationLat");
        //    }
        //}
        ///// <summary>
        ///// The GeoCordinate infomration of the farmers market
        ///// </summary>
        //public double GpsLocationLon
        //{
        //    get
        //    {
        //        return _GpsLocation.Longitude;
        //    }
        //    set
        //    {
        //        _GpsLocation.Longitude = value;
        //        NotifyPropertyChanged("GpsLocationLon");
        //    }
        //}
        /// <summary>
        /// The GeoCordinate infomration of the farmers market
        /// </summary>
        public GeoCoordinate GpsLocationInfo
        {
            get
            {
                return _GpsLocation;
            }

        }
        /// <summary>
        /// The website address
        /// </summary>
        public string Website
        {
            get
            {
                return _WebUrl;
            }
            set
            {
                _WebUrl = value;
                NotifyPropertyChanged("Website");
            }
        }
        /// <summary>
        /// The email address to contact the famers market
        /// </summary>
        public string ContactEmail
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                NotifyPropertyChanged("ContactEmail");
            }
        }
        /// <summary>
        /// The image Uri, can be local or remote
        /// </summary>
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
                NotifyPropertyChanged("Phone");
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
