using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace TopCarrotMobile.AppCode
{
    public class MobileDatabaseContext : DataContext
    {
        //Setup the connection string for the local database
        public static string LocalDbConnectionString = "Data Source=isostore:/LocalTopCarrotDb.sdf";

        //Pass the connection string to the base class
        public MobileDatabaseContext(string LocalDbConnectionString) : base(LocalDbConnectionString) { }


        //Generate the Subscriber information table
        public Table<Subscriber> Subscriber;
        public Table<Location> Location;
        public Table<FavoriteCommodities> FavoriteCommodities;
        public Table<FavoriteMarkets> FavoriteMarkets;

    }


    //This class discribes and creates the Subscriber table. This table holds the information
    //of the subscriber used by Virtual Vault to indentify the user and their contact and
    //shipping information
    [Table(Name = "Subscriber")]
    public class Subscriber : INotifyPropertyChanged, INotifyPropertyChanging
    {
        //Define the column variables to hold the values to be stored in column fields
        private int sId; //Holds the Id value for the primary key in this table
        private string sFirstName; //Holds subscribers first name
        private string sMiddleName; //Holds the subscribers middle name
        private string sLastName; //Holds the subscribers last name
        private string sPhone; //Home phone land-line
        private string sMobile; //Mobile phone number
        private string sFax; //Fax number
        private string sWorkPhone; //Work phone number
        private string sAddress1; //First line of subscribers address
        private string sAddress2; //Second line of address
        private string sCity; //Address City
        private string sState; //Address State
        private string sZip; //Zip code
        private string sCountry; //Country

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion


        //Primary key column
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return sId;
            }
            set
            {
                if (sId != value)
                {
                    NotifyPropertyChanging("Id");
                    sId = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        //Subscriber first name
        [Column(DbType = "nvarchar(15) NOT NULL", CanBeNull = false, Name = "FirstName", AutoSync = AutoSync.Default)]
        public string FirstName
        {
            get
            {
                return sFirstName;
            }
            set
            {
                if (sFirstName != value)
                {
                    NotifyPropertyChanging("FirstName");
                    sFirstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }
        //Subscribers middle name
        [Column(DbType = "nvarchar(15)", CanBeNull = true, Name = "MiddleName", AutoSync = AutoSync.Default)]
        public string MiddleName
        {
            get
            {
                return sMiddleName;
            }
            set
            {
                if (sMiddleName != value)
                {
                    NotifyPropertyChanging("MiddleName");
                    sMiddleName = value;
                    NotifyPropertyChanged("MiddleName");
                }
            }
        }
        //Subscribers last name
        [Column(DbType = "nvarchar(25) NOT NULL", CanBeNull = false, Name = "LastName", AutoSync = AutoSync.Default)]
        public string LastName
        {
            get
            {
                return sLastName;
            }
            set
            {
                if (sLastName != value)
                {
                    NotifyPropertyChanging("LastName");
                    sLastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }
        //Phone (land-line) number of subscriber
        [Column(DbType = "nvarchar(12) NOT NULL", CanBeNull = false, Name = "Phone", AutoSync = AutoSync.Default)]
        public string Phone
        {
            get
            {
                return sPhone;
            }
            set
            {
                if (sPhone != value)
                {
                    NotifyPropertyChanging("Phone");
                    sPhone = value;
                    NotifyPropertyChanged("Phone");
                }
            }
        }
        //Subscribers mobile or cellular phone number
        [Column(DbType = "nvarchar(12) NOT NULL", CanBeNull = false, Name = "Mobile", AutoSync = AutoSync.Default)]
        public string Mobile
        {
            get
            {
                return sMobile;
            }
            set
            {
                if (sMobile != value)
                {
                    NotifyPropertyChanging("Mobile");
                    sMobile = value;
                    NotifyPropertyChanged("Mobile");
                }
            }
        }
        //Subscribers fax number 
        [Column(DbType = "nvarchar(12)", CanBeNull = true, Name = "Fax", AutoSync = AutoSync.Default)]
        public string Fax
        {
            get
            {
                return sFax;
            }
            set
            {
                if (sFax != value)
                {
                    NotifyPropertyChanging("Fax");
                    sFax = value;
                    NotifyPropertyChanged("Fax");
                }
            }
        }
        //Subscribers work phone (land-line)
        [Column(DbType = "nvarchar(12)", CanBeNull = true, Name = "WorkPhone", AutoSync = AutoSync.Default)]
        public string WorkPhone
        {
            get
            {
                return sWorkPhone;
            }
            set
            {
                if (sWorkPhone != value)
                {
                    NotifyPropertyChanging("WorkPhone");
                    sWorkPhone = value;
                    NotifyPropertyChanged("WorkPhone");
                }
            }
        }
        //Subscribers mailing address
        [Column(DbType = "nvarchar(50) NOT NULL", CanBeNull = false, Name = "MailingAddress1", AutoSync = AutoSync.Default)]
        public string MailingAddress1
        {
            get
            {
                return sAddress1;
            }
            set
            {
                if (sAddress1 != value)
                {
                    NotifyPropertyChanging("Address1");
                    sAddress1 = value;
                    NotifyPropertyChanged("Address1");
                }
            }
        }
        //Subscirbers mailing adddress line 2
        [Column(DbType = "nvarchar(50)", CanBeNull = true, Name = "MailingAddress2", AutoSync = AutoSync.Default)]
        public string MailingAddress2
        {
            get
            {
                return sAddress2;
            }
            set
            {
                if (sAddress2 != value)
                {
                    NotifyPropertyChanging("Address2");
                    sAddress2 = value;
                    NotifyPropertyChanged("Address2");
                }
            }
        }
        //Subscribers City mailing address
        [Column(DbType = "nvarchar(30) NOT NULL", CanBeNull = false, Name = "City", AutoSync = AutoSync.Default)]
        public string City
        {
            get
            {
                return sCity;
            }
            set
            {
                if (sCity != value)
                {
                    NotifyPropertyChanging("City");
                    sCity = value;
                    NotifyPropertyChanged("City");
                }
            }
        }
        //Subscribers state of mailing address 
        [Column(DbType = "nvarchar(40) NOT NULL", CanBeNull = false, Name = "State", AutoSync = AutoSync.Default)]
        public string State
        {
            get
            {
                return sState;
            }
            set
            {
                if (sState != value)
                {
                    NotifyPropertyChanging("State");
                    sState = value;
                    NotifyPropertyChanged("State");
                }
            }
        }
        //Subscribers Zip Code of mailing address 
        [Column(DbType = "nvarchar(5) NOT NULL", CanBeNull = false, Name = "Zip", AutoSync = AutoSync.Default)]
        public string Zip
        {
            get
            {
                return sZip;
            }
            set
            {
                if (sZip != value)
                {
                    NotifyPropertyChanging("Zip");
                    sZip = value;
                    NotifyPropertyChanged("Zip");
                }
            }
        }
        //Subscriber country of mailing address
        [Column(DbType = "nvarchar(40) NOT NULL", CanBeNull = false, Name = "Country", AutoSync = AutoSync.Default)]
        public string Country
        {
            get
            {
                return sCountry;
            }
            set
            {
                if (sCountry != value)
                {
                    NotifyPropertyChanging("Country");
                    sCountry = value;
                    NotifyPropertyChanged("Country");
                }
            }
        }

    }

    [Table(Name = "Location")]
    public class Location : INotifyPropertyChanged, INotifyPropertyChanging
    {
        //Setup the variables for the location table
        private int sId; //This is the table primary key
        private float sLongitude; //Standard GPS longitude
        private float sLatitude; //Standard GPS latitude
        private string sZip; //Location zip code for background service
        private int sCount; //The number of times this location has been found


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion

        //Primary key column
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return sId;
            }
            set
            {
                if (sId != value)
                {
                    NotifyPropertyChanging("Id");
                    sId = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        //Longitude column
        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "FLOAT NOT NULL", CanBeNull = false, AutoSync = AutoSync.Default)]
        public float Longitude
        {
            get
            {
                return sLongitude;
            }
            set
            {
                if (sLongitude != value)
                {
                    NotifyPropertyChanging("Longitude");
                    sLongitude = value;
                    NotifyPropertyChanged("Longitude");
                }
            }
        }

        //Latitude column
        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "FLOAT NOT NULL", CanBeNull = false, AutoSync = AutoSync.Default)]
        public float Latitude
        {
            get
            {
                return sLatitude;
            }
            set
            {
                if (sLatitude != value)
                {
                    NotifyPropertyChanging("Latitude");
                    sLatitude = value;
                    NotifyPropertyChanged("Latitude");
                }
            }
        }

        //Zip column
        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "nvarchar(5) NOT NULL", CanBeNull = false, AutoSync = AutoSync.Default)]
        public string Zip
        {
            get
            {
                return sZip;
            }
            set
            {
                if (sZip != value)
                {
                    NotifyPropertyChanging("Zip");
                    sZip = value;
                    NotifyPropertyChanged("Zip");
                }
            }
        }

        //Count column
        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "INT NOT NULL", CanBeNull = false, AutoSync = AutoSync.Default)]
        public int Count
        {
            get
            {
                return sCount;
            }
            set
            {
                if (sCount != value)
                {
                    NotifyPropertyChanging("Count");
                    sCount = value;
                    NotifyPropertyChanged("Count");
                }
            }
        }

    }
    /// <summary>
    /// 
    /// </summary>
    [Table(Name = "FavoriteCommodities")]
    public class FavoriteCommodities : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int sId;
        private int intPluId;
        private string sPlu;
        private string sName;
        private string sImageUri;
        private string sDescription;
        private string sVariety;
        private string sSize;


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, Name = "Id", AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return sId;
            }
            set
            {
                if (sId != value)
                {
                    NotifyPropertyChanging("Id");
                    sId = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "INT NOT NULL", CanBeNull = false, Name = "PluId", AutoSync = AutoSync.Default)]
        public int PluId
        {
            get
            {
                return intPluId;
            }
            set
            {
                if (intPluId != value)
                {
                    NotifyPropertyChanging("PluId");
                    intPluId = value;
                    NotifyPropertyChanged("PluId");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "nvarchar(7) NOT NULL", CanBeNull = false, Name = "Plu", AutoSync = AutoSync.Default)]
        public string Plu
        {
            get
            {
                return sPlu;
            }
            set
            {
                if (sPlu != value)
                {
                    NotifyPropertyChanging("Plu");
                    sPlu = value;
                    NotifyPropertyChanged("Plu");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "nvarchar(50) NOT NULL", CanBeNull = false, Name = "Name", AutoSync = AutoSync.Default)]
        public string Name
        {
            get
            {
                return sName;
            }
            set
            {
                if (sName != value)
                {
                    NotifyPropertyChanging("Name");
                    sName = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "nvarchar(255) NOT NULL", CanBeNull = false, Name = "Image", AutoSync = AutoSync.Default)]
        public string Image
        {
            get
            {
                return sImageUri;
            }
            set
            {
                if (sImageUri != value)
                {
                    NotifyPropertyChanging("Image");
                    sImageUri = value;
                    NotifyPropertyChanged("Image");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "nvarchar(255) NOT NULL", CanBeNull = false, Name = "Size", AutoSync = AutoSync.Default)]
        public string Size
        {
            get
            {
                return sSize;
            }
            set
            {
                if (sSize != value)
                {
                    NotifyPropertyChanging("Size");
                    sSize = value;
                    NotifyPropertyChanged("Size");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "nvarchar(60) NOT NULL", CanBeNull = false, Name = "Variety", AutoSync = AutoSync.Default)]
        public string Variety
        {
            get
            {
                return sVariety;
            }
            set
            {
                if (sVariety != value)
                {
                    NotifyPropertyChanging("Variety");
                    sVariety = value;
                    NotifyPropertyChanged("Variety");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "nvarchar(255) NOT NULL", CanBeNull = false, Name = "Description", AutoSync = AutoSync.Default)]
        public string Description
        {
            get
            {
                return sDescription;
            }
            set
            {
                if (sDescription != value)
                {
                    NotifyPropertyChanging("Description");
                    sDescription = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    [Table(Name = "FavoriteMarkets")]
    public class FavoriteMarkets : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int sId;
        private string sUrl;
        private string sName;
        private string sImage;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, Name = "Id", AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return sId;
            }
            set
            {
                if (sId != value)
                {
                    NotifyPropertyChanging("Id");
                    sId = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "nvarchar(25) NOT NULL", CanBeNull = false, Name = "Url", AutoSync = AutoSync.Default)]
        public string Url
        {
            get
            {
                return sUrl;
            }
            set
            {
                if (sUrl != value)
                {
                    NotifyPropertyChanging("Url");
                    sUrl = value;
                    NotifyPropertyChanged("Url");
                }
            }
        }

        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "nvarchar(30) NOT NULL", CanBeNull = false, Name = "Name", AutoSync = AutoSync.Default)]
        public string Name
        {
            get
            {
                return sName;
            }
            set
            {
                if (sName != value)
                {
                    NotifyPropertyChanging("Name");
                    sName = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        [Column(IsPrimaryKey = false, IsDbGenerated = false, DbType = "nvarchar(10) NOT NULL", CanBeNull = false, Name = "Image", AutoSync = AutoSync.Default)]
        public string Image
        {
            get
            {
                return sImage;
            }
            set
            {
                if (sImage != value)
                {
                    NotifyPropertyChanging("Image");
                    sImage = value;
                    NotifyPropertyChanged("Image");
                }
            }
        }
    }

}
