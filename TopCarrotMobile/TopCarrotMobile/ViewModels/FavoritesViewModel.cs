using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Services.Client;
using System.Net;
using Microsoft.Phone.Net.NetworkInformation;

namespace TopCarrotMobile
{
    public class FavoritesViewModel : INotifyPropertyChanged
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
        public FavoritesViewModel()
        {
            this.MyFavorites = new ObservableCollection<FavoritesModel>();
            this.MyFarmersMarkets = new ObservableCollection<FarmersMarketModel>();
            this.MyAreaMarkets = new ObservableCollection<AreaMarketModel>();
            DeviceNetworkInformation.NetworkAvailabilityChanged += 
                new System.EventHandler<NetworkNotificationEventArgs>(DeviceNetworkInformation_NetworkAvailabilityChanged);
            GetNetworkInfo();
        }

        void DeviceNetworkInformation_NetworkAvailabilityChanged(object sender, NetworkNotificationEventArgs e)
        {
            GetNetworkInfo();
        }
        
        /// <summary>
        /// A data service collection for FavoritesModel objects on the favorites pivot item.
        /// </summary>
        public ObservableCollection<FavoritesModel> MyFavorites { get; private set; }
        /// <summary>
        /// A data service collection for FavoritesModel objects on the farmers mmarket pivot item.
        /// </summary>
        public ObservableCollection<FarmersMarketModel> MyFarmersMarkets { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<AreaMarketModel> MyAreaMarkets { get; private set; }
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
                if(_MobileOperator != value)
                {
                    _MobileOperator = value;
                    NotifyPropertyChanged("MobileOperator");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsODataReachable
        {
            get
            {
                return _OdataReachable;
            }
            private set
            {
                if(_OdataReachable != value)
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
            this.MyFavorites.Add(new FavoritesModel() { Id = 17, PluId = 387, Plu = "3001", Name = "sparugus", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });
            this.MyFavorites.Add(new FavoritesModel() { Id = 91, PluId = 346, Plu = "3001", Name = "Asparugus", Variety = "------------------", Description = "Senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend", Size = "Small", ImageUri = "" });
            this.MyFavorites.Add(new FavoritesModel() { Id = 23, PluId = 567, Plu = "4659", Name = "Oranges", Variety = "------------------", Description = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat", Size = "Small", ImageUri = "" });
            this.MyFavorites.Add(new FavoritesModel() { Id = 99, PluId = 286, Plu = "2008", Name = "Grapes", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });
            this.MyFavorites.Add(new FavoritesModel() { Id = 25, PluId = 982, Plu = "5648", Name = "Tomatos", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });
            this.MyFavorites.Add(new FavoritesModel() { Id = 58, PluId = 1235, Plu = "6974", Name = "Bananas", Variety = "------------------", Description = "Senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend", Size = "Small", ImageUri = "" });
            this.MyFavorites.Add(new FavoritesModel() { Id = 12, PluId = 1258, Plu = "3687", Name = "Letus", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });
            this.MyFavorites.Add(new FavoritesModel() { Id = 52, PluId = 687, Plu = "6894", Name = "Broccoli", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });
            this.MyFavorites.Add(new FavoritesModel() { Id = 87, PluId = 689, Plu = "2879", Name = "Carrots", Variety = "------------------", Description = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat", Size = "Small", ImageUri = "" });
            this.MyFavorites.Add(new FavoritesModel() { Id = 56, PluId = 348, Plu = "2358", Name = "Cucumber", Variety = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "" });
            
            //Farmers Market Sample Data
            this.MyFarmersMarkets.Add(new FarmersMarketModel() { Id=1, FarmerMarketOdataId=341, Name="Great Lands Farmers Market", Specialty="Organic Produce", Description="Senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend", Size="Small", ImageUri="", Website="www.greatfarmersmarket.com", ContactEmail="farmer@example.com", Phone="310 555-1212"});
            this.MyFarmersMarkets.Add(new FarmersMarketModel() { Id=2, FarmerMarketOdataId=567, Name="Wilson Park Farmers Market", Specialty="Organic Fruits", Description="Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat", Size="Small", ImageUri="", Website="www.greatfarmersmarket.com", ContactEmail="farmer@example.com", Phone="310 555-1212"});
            this.MyFarmersMarkets.Add(new FarmersMarketModel() { Id=99, FarmerMarketOdataId=286, Name="3rd Street Pramanod Farmers Market", Specialty="California Grown",  Description="Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size="Small", ImageUri="", Website="www.greatfarmersmarket.com", ContactEmail="farmer@example.com", Phone="310 555-1212"});
            this.MyFarmersMarkets.Add(new FarmersMarketModel() { Id=25, FarmerMarketOdataId=982, Name="Mission Farmers Market", Specialty="Variety of Produce", Description="ksdfhsdfhlsdkjflkdsjfhlskdfhldskhf", Size="Small", ImageUri="", Website="www.greatfarmersmarket.com", ContactEmail="farmer@example.com", Phone="310 555-1212"});
            this.MyFarmersMarkets.Add(new FarmersMarketModel() { Id=58, FarmerMarketOdataId=1235, Name="Great Lands East Farmers Market", Specialty="------------------",  Description="ksdfhsdfhlsdkjflkdsjfhlskdfhldskhf", Size="Small", ImageUri="", Website="www.greatfarmersmarket.com", ContactEmail="farmer@example.com", Phone="310 555-1212"});
            this.MyFarmersMarkets.Add(new FarmersMarketModel() { Id=12, FarmerMarketOdataId=1258, Name="Market", Specialty="------------------", Description="ksdfhsdfhlsdkjflkdsjfhlskdfhldskhf", Size="Small", ImageUri="", Website="www.greatfarmersmarket.com", ContactEmail="farmer@example.com", Phone="310 555-1212"});
            this.MyFarmersMarkets.Add(new FarmersMarketModel() { Id=52, FarmerMarketOdataId=687, Name="South Lands Farmers Market", Specialty="------------------", Description="ksdfhsdfhlsdkjflkdsjfhlskdfhldskhf", Size="Small", ImageUri="", Website="www.greatfarmersmarket.com", ContactEmail="farmer@example.com", Phone="310 555-1212"});
            this.MyFarmersMarkets.Add(new FarmersMarketModel() { Id=87, FarmerMarketOdataId=689, Name="Just Good Stuff Farmers Market", Specialty="------------------", Description="Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat", Size="Small", ImageUri="", Website="www.greatfarmersmarket.com", ContactEmail="farmer@example.com", Phone="310 555-1216"});
            this.MyFarmersMarkets.Add(new FarmersMarketModel() { Id=56, FarmerMarketOdataId=348, Name="Great Lands West Farmers Market", Specialty="------------------", Description="ksdfhsdfhlsdkjflkdsjfhlskdfhldskhf", Size="Small", ImageUri="", Website="www.greatfarmersmarket.com", ContactEmail="farmer@example.com", Phone="310 555-1212"});
            this.MyFarmersMarkets.Add(new FarmersMarketModel() { Id=15, FarmerMarketOdataId = 105, Name = "Farmers Market", Specialty = "------------------", Description = "ksdfhsdfhlsdkjflkdsjfhlskdfhldskhf", Size = "Small", ImageUri = "", Website = "www.greatfarmersmarket.com", ContactEmail = "farmer@example.com", Phone = "310 555-1212" });

            //Area Market Sample Data
            this.MyAreaMarkets.Add(new AreaMarketModel() { Id = 1, FarmerMarketOdataId = 341, Name = "Whole Foods Market", Specialty = "Fine Produce", Description = "Senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend", Size = "Small", ImageUri = "", Website = "www.greatfarmersmarket.com", ContactEmail = "farmer@example.com", Phone = "310 555-1212" });
            this.MyAreaMarkets.Add(new AreaMarketModel() { Id = 2, FarmerMarketOdataId = 567, Name = "Trader Joes", Specialty = "International Foods", Description = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat", Size = "Small", ImageUri = "", Website = "www.greatfarmersmarket.com", ContactEmail = "farmer@example.com", Phone = "310 555-1212" });
            this.MyAreaMarkets.Add(new AreaMarketModel() { Id = 99, FarmerMarketOdataId = 286, Name = "3rd Street Pramanod Farmers Market", Specialty = "California Grown", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "", Website = "www.greatfarmersmarket.com", ContactEmail = "farmer@example.com", Phone = "310 555-1212" });
            this.MyAreaMarkets.Add(new AreaMarketModel() { Id = 25, FarmerMarketOdataId = 982, Name = "Mission Farmers Market", Specialty = "Variety of Produce", Description = "Senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend", Size = "Small", ImageUri = "", Website = "www.greatfarmersmarket.com", ContactEmail = "farmer@example.com", Phone = "310 555-1212" });
            this.MyAreaMarkets.Add(new AreaMarketModel() { Id = 58, FarmerMarketOdataId = 1235, Name = "South Bay Market", Specialty = "Fine Local Produce", Description = "Senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend", Size = "Small", ImageUri = "", Website = "www.greatfarmersmarket.com", ContactEmail = "farmer@example.com", Phone = "310 555-1212" });
            this.MyAreaMarkets.Add(new AreaMarketModel() { Id = 12, FarmerMarketOdataId = 1258, Name = "Market", Specialty = "------------------", Description = "Senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend", Size = "Small", ImageUri = "", Website = "www.greatfarmersmarket.com", ContactEmail = "farmer@example.com", Phone = "310 555-1212" });
            this.MyAreaMarkets.Add(new AreaMarketModel() { Id = 52, FarmerMarketOdataId = 687, Name = "South Lands Farmers Market", Specialty = "------------------", Description = "Senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend", Size = "Small", ImageUri = "", Website = "www.greatfarmersmarket.com", ContactEmail = "farmer@example.com", Phone = "310 555-1212" });
            this.MyAreaMarkets.Add(new AreaMarketModel() { Id = 87, FarmerMarketOdataId = 689, Name = "Just Good Stuff Farmers Market", Specialty = "------------------", Description = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat", Size = "Small", ImageUri = "", Website = "www.greatfarmersmarket.com", ContactEmail = "farmer@example.com", Phone = "310 555-1216" });
            this.MyAreaMarkets.Add(new AreaMarketModel() { Id = 56, FarmerMarketOdataId = 348, Name = "Great Lands West Market", Specialty = "------------------", Description = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", Size = "Small", ImageUri = "", Website = "www.greatfarmersmarket.com", ContactEmail = "farmer@example.com", Phone = "310 555-1212" });
            this.MyAreaMarkets.Add(new AreaMarketModel() { Id = 15, FarmerMarketOdataId = 105, Name = "Market", Specialty = "------------------", Description = "Senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend", Size = "Small", ImageUri = "", Website = "www.greatfarmersmarket.com", ContactEmail = "farmer@example.com", Phone = "310 555-1212" });
            
            
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
