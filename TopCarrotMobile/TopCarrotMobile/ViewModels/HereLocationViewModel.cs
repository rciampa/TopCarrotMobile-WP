using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Services.Client;
using System.Net;
using Microsoft.Phone.Net.NetworkInformation;

namespace TopCarrotMobile
{
    public class HereLocationViewModel : INotifyPropertyChanged
    {
        private string _Interface;
        private bool _IsnetworkUp;
        private string _MobileOperator;
        private bool _IsWiFiEnabled;
        private bool _IsCellularDataEnabled;
        private bool _NetworkResolution;
        private bool _OdataReachable;
        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Constructor
        /// </summary>
        public HereLocationViewModel()
        {
            this.MyHereLocationData = new ObservableCollection<HereModel>();
            DeviceNetworkInformation.NetworkAvailabilityChanged += 
                new System.EventHandler<NetworkNotificationEventArgs>(DeviceNetworkInformation_NetworkAvailabilityChanged);
        }

        void DeviceNetworkInformation_NetworkAvailabilityChanged(object sender, NetworkNotificationEventArgs e)
        {
            GetNetworkInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<HereModel> MyHereLocationData { get; private set; }
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
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
        /// 
        /// </summary>
        public bool IsCellularDataEnabled
        {
            get
            {
                return _IsCellularDataEnabled;
            }
            private set
            {
                if (value != _IsCellularDataEnabled)
                {
                    _IsCellularDataEnabled = value;
                    NotifyPropertyChanged("IsCellularDataEnabled");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsWiFiEnabled
        {
            get
            {
                return _IsWiFiEnabled;
            }
            private set
            {
                if (value != _IsWiFiEnabled)
                {
                    _IsWiFiEnabled = value;
                    NotifyPropertyChanged("IsWiFiEnabled");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsNetworkUp
        {
            get
            {
                return _IsnetworkUp;
            }
            private set
            {
                if (_IsnetworkUp != value)
                {
                    _IsnetworkUp = value;
                    NotifyPropertyChanged("IsNetworkUp");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobileOperator
        {
            get
            {
                return _MobileOperator;
            }
            private set
            {
                if (_MobileOperator != value)
                {
                    _MobileOperator = value;
                    NotifyPropertyChanged("MobileOperator");
                }
            }
        }
        public bool IsODataReachable
        {
            get
            {
                return _OdataReachable;
            }
            private set
            {
                if (_OdataReachable != value)
                {
                    _OdataReachable = value;
                    NotifyPropertyChanged("IsODataReachable");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void GetNetworkInfo()
        {
            this.MobileOperator = DeviceNetworkInformation.CellularMobileOperator;
            this.IsWiFiEnabled = DeviceNetworkInformation.IsWiFiEnabled;
            this.IsCellularDataEnabled = DeviceNetworkInformation.IsCellularDataEnabled;
            this.IsNetworkUp = DeviceNetworkInformation.IsNetworkAvailable;
            //Check to see that we can reach our oData host port
            if (this.IsNetworkUp)
            {
                DnsEndPoint TopCarrotEndPoint = new DnsEndPoint("odata.topcarrot.net", 4000);
                DeviceNetworkInformation.ResolveHostNameAsync(TopCarrotEndPoint, NetResolutionCallback, null);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NetInfo"></param>
        void NetResolutionCallback(NameResolutionResult NetResInfo)
        {
            if (NetResInfo.NetworkErrorCode == NetworkError.Success)
            {
                this.IsODataReachable = true;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.MyHereLocationData.Add(new HereModel() {PluId = 387, Plu = "3001", Name = "sparugus", CropId="CA8974983469", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });
            this.MyHereLocationData.Add(new HereModel() {PluId = 346, Plu = "3001", Name = "Asparugus", CropId="AZ89745873489", Variety = "------------------", Description = "Senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend", Size = "Small", ImageUri = "" });
            this.MyHereLocationData.Add(new HereModel() {PluId = 567, Plu = "4659", Name = "Oranges", CropId="CA89774983469", Variety = "------------------", Description = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat", Size = "Small", ImageUri = "" });
            this.MyHereLocationData.Add(new HereModel() {PluId = 286, Plu = "2008", Name = "Grapes", CropId="ID3974983469", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });
            this.MyHereLocationData.Add(new HereModel() {PluId = 982, Plu = "5648", Name = "Tomatos", CropId="CA8574983469", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });
            this.MyHereLocationData.Add(new HereModel() {PluId = 1235, Plu = "6974", Name = "Bananas", CropId="WA8976683469", Variety = "------------------", Description = "Senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend", Size = "Small", ImageUri = "" });
            this.MyHereLocationData.Add(new HereModel() {PluId = 1258, Plu = "3687", Name = "Letus", CropId="CA8994983469", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });
            this.MyHereLocationData.Add(new HereModel() {PluId = 687, Plu = "6894", Name = "Broccoli", CropId="TX8978883469", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });
            this.MyHereLocationData.Add(new HereModel() {PluId = 689, Plu = "2879", Name = "Carrots", CropId="IA8900983469", Variety = "------------------", Description = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat", Size = "Small", ImageUri = "" });
            this.MyHereLocationData.Add(new HereModel() {PluId = 348, Plu = "2358", Name = "Cucumber", CropId="CA8976583469", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });

            //Set the flag to show that the data was loaded
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
