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
using System.IO.IsolatedStorage;

namespace ScheduledTaskAgentLocationService
{
    public class MobileTaskAppSettings
    {

        // Top Carrot Mobile settings
        IsolatedStorageSettings settings;


        // The default value of our settings
        const bool MarketInfoServiceDefault = true;
        const bool RoadStandServiceDefault = true;
        const bool TrackAreaFarmersMarketsDefault = false;
        const bool TrackAreaMarketsDefault = false;
        const bool NotificationsEnabledDefault = false;
        const bool FavoritesSyncDefault = false;
        const bool LocationServiceDefault = false;
        const bool TermsAcceptedDefault = false;
        const bool EmailSearchResultsDefault = false;
        const bool WebServicesEnabledDefault = false;
        const double NotificationLevelDefault = 5.0;
        const string UsernameSettingDefault = "";
        const string PasswordSettingDefault = "";
        const bool SaveUserPasswordDefault = false;

        DateTime AppConfigDateDefault = DateTime.Now;
        const string BingMapUriBaseDefault = "https://dev.virtualearth.net/REST/v1/Locations/";
        const string BingMapsKeyDefault = "Aj1zoVd5xsjqfQq501ls9I09WiN7W3DruAOmnfSxHCey8ugmUqXAFYnSISuE-xdK";
        const string oDataServiceUriDefault = "http://odata.topcarrot.mobi:4200/TopCarrotDataService.svc";
        const bool UlimitedSearchEnabledDefault = false;
        const string PushChannelUriDefault = "";
        const bool IsPushChannelConnectedDefault = false;
        const string DefaultDatabaseNameDefault = "LocalTopCarrotDb.sdf";
        const string DefaultDatabasePathDefault = "/";
        const string BakDatabaseNameDefault = "LocalTopCarrotDbBak.sdf";
        const string BakDatabasePathDefault = "/DbBackup/";
        const string UpgradeDatabaseNameDefault = "LocalTopCarrotDbUp.sdf";
        const string UpgradeDatabasePathDefault = "/DbUpTemp/";



        // The key names of our settings
        //Create the default setup configuration for applicaiton settings
        const string WebServicesEnabledKeyName = "WebServicesEnabled";
        const string MarketInfoServiceKeyName = "MarketInfoService";
        const string RoadStandServiceKeyName = "RoadStandService";
        const string TrackAreaFarmersMarketsKeyName = "TrackAreaFarmersMarkets";
        const string TrackAreaMarketsKeyName = "TrackAreaMarkets";
        const string NotificationsEnabledKeyName = "NotificationsEnabled";
        const string FavoritesSyncKeyName = "FavoritesSync";
        const string NotificationLevelKeyName = "NotificationLevel";
        const string TermsAcceptedKeyName = "TermsAccepted";
        const string LocationServiceKeyName = "LocationService";
        const string UsernameSettingKeyName = "UsernameSetting";
        const string PasswordSettingKeyName = "PasswordSetting";
        const string SaveUserPasswordKeyName = "SaveUserPassword";

        const string AppConfigDateKeyName = "AppConfigDate";
        const string BingMapUriBaseKeyName = "BingMapUriBase";
        const string BingMapsKeyKeyName = "BingMapsKey";
        const string oDataServiceUriKeyName = "oDataServiceUri";
        const string UlimitedSearchEnabledKeyName = "UlimitedSearchEnabled";
        const string PushChannelUriKeyName = "PushChannelUri";
        const string IsPushChannelConnectedKeyName = "IsPushChannelConnected";
        const string EmailSearchResultsKeyName = "EmailSearchResults";
        const string DefaultDatabaseNameKeyName = "DefaultDatabaseName";
        const string DefaultDatabasePathKeyName = "DefaultDatabasePath";
        const string BakDatabaseNameKeyName = "BakDatabaseName";
        const string BakDatabasePathKeyName = "BakDatabasePath";
        const string UpgradeDatabaseNameKeyName = "UpgradeDatabaseName";
        const string UpgradeDatabasePathKeyName = "UpgradeDatabasePath";

        /// <summary>
        /// Constructor that gets the application settings.
        /// </summary>
        public MobileTaskAppSettings()
        {
            // Get the settings for this application.
            settings = IsolatedStorageSettings.ApplicationSettings;
        }
        /// <summary>
        /// This method sets all the defauls for the application
        /// </summary>
        /// <param name="IsoStoreSettings"></param>
        /// <returns></returns>
        public bool AreAppDefaultSettingsReady()
        {

            bool AppSettingsCondition = false;

            //If we have a Db file we need to check that the users setting exist, if there
            //are none than we need to create them. We first need to check if the user has a
            //websrvice enabled account, if so then retrieve the settings, if not create the
            //default configuration.
            if (settings.Count > 0)
            {
                settings.Add(WebServicesEnabledKeyName, WebServicesEnabledDefault);
                settings.Add(MarketInfoServiceKeyName, MarketInfoServiceDefault);

                AppSettingsCondition = true;
            }

            return AppSettingsCondition;

        }
        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (settings.Contains(Key))
            {
                // If the value has changed
                if (settings[Key] != value)
                {
                    // Store the new value
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }

            return valueChanged;
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetValueOrDefault<T>(string Key, T defaultValue)
        {
            T value;

            // If the key exists, retrieve the value.
            if (settings.Contains(Key))
            {
                value = (T)settings[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }

            return value;
        }

        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save()
        {
            settings.Save();
        }


        /// <summary>
        /// Property to get and set MarketInfoService toggle Setting Key.
        /// </summary>
        public bool MarketInfoServiceToggle
        {
            get
            {
                return GetValueOrDefault<bool>(MarketInfoServiceKeyName, MarketInfoServiceDefault);
            }
            set
            {
                if (AddOrUpdateValue(MarketInfoServiceKeyName, value))
                {
                    Save();
                }
            }
        }
        /// <summary>
        /// Property to get and set RoadStandService toggle Setting Key.
        /// </summary>
        public bool RoadStandServiceToggle
        {
            get
            {
                return GetValueOrDefault<bool>(RoadStandServiceKeyName, RoadStandServiceDefault);
            }
            set
            {
                if (AddOrUpdateValue(RoadStandServiceKeyName, value))
                {
                    Save();
                }
            }
        }
        /// <summary>
        /// Property to get and set FavoritesSync toggle Setting Key.
        /// </summary>
        public bool FavoritesSyncToggle
        {
            get
            {
                return GetValueOrDefault<bool>(FavoritesSyncKeyName, FavoritesSyncDefault);
            }
            set
            {
                if (AddOrUpdateValue(FavoritesSyncKeyName, value))
                {
                    Save();
                }
            }
        }
        /// <summary>
        /// Property to get and set Notifications toggle Setting Key.
        /// </summary>
        public bool NotificationsToggle
        {
            get
            {
                return GetValueOrDefault<bool>(NotificationsEnabledKeyName, NotificationsEnabledDefault);
            }
            set
            {
                if (AddOrUpdateValue(NotificationsEnabledKeyName, value))
                {
                    Save();
                }
            }
        }
        /// <summary>
        /// Property to get and set NotificationLevel slider Setting Key.
        /// </summary>
        public double NotificationLevelSlider
        {
            get
            {
                return GetValueOrDefault<double>(NotificationLevelKeyName, NotificationLevelDefault);
            }
            set
            {
                if (AddOrUpdateValue(NotificationLevelKeyName, value))
                {
                    Save();
                }
            }
        }
        /// <summary>
        /// Property to get and set TrackFarmersMarkets toggle Setting Key.
        /// </summary>
        public bool TrackFarmersMarketsToggle
        {
            get
            {
                return GetValueOrDefault<bool>(TrackAreaFarmersMarketsKeyName, TrackAreaFarmersMarketsDefault);
            }
            set
            {
                if (AddOrUpdateValue(TrackAreaFarmersMarketsKeyName, value))
                {
                    Save();
                }
            }
        }
        /// <summary>
        /// Property to get and set TrackAreaMarkets toggle Setting Key.
        /// </summary>
        public bool TrackAreaMarketsToggle
        {
            get
            {
                return GetValueOrDefault<bool>(TrackAreaMarketsKeyName, TrackAreaMarketsDefault);
            }
            set
            {
                if (AddOrUpdateValue(TrackAreaMarketsKeyName, value))
                {
                    Save();
                }
            }
        }
        /// <summary>
        /// Property to get and set a Username Setting Key.
        /// </summary>
        public string UsernameSetting
        {
            get
            {
                return GetValueOrDefault<string>(UsernameSettingKeyName, UsernameSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(UsernameSettingKeyName, value))
                {
                    Save();
                }
            }
        }
        /// <summary>
        /// Property to get and set a Password Setting Key.
        /// </summary>
        public string PasswordSetting
        {
            get
            {
                return GetValueOrDefault<string>(PasswordSettingKeyName, PasswordSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(PasswordSettingKeyName, value))
                {
                    Save();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool SaveUserPassword
        {
            get
            {
                return GetValueOrDefault<bool>(SaveUserPasswordKeyName, SaveUserPasswordDefault);
            }
            set
            {
                if (AddOrUpdateValue(SaveUserPasswordKeyName, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string BingMapKey
        {
            get
            {
                return GetValueOrDefault<string>(BingMapsKeyKeyName, BingMapsKeyDefault);
            }
            set
            {
                if (AddOrUpdateValue(BingMapsKeyDefault, value))
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string BingMapBaseUri
        {
            get
            {
                return GetValueOrDefault<string>(BingMapUriBaseKeyName, BingMapUriBaseDefault);
            }
            set
            {
                if (AddOrUpdateValue(BingMapUriBaseKeyName, value))
                {
                    Save();
                }
            }
        }
    }
}
