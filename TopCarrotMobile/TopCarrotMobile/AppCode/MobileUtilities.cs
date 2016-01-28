using System;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Notification;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using System.Xml.Serialization;

namespace TopCarrotMobile.AppCode
{
    /// <summary>
    /// 
    /// </summary>
    public class MobilePushChannelUtilities : PhoneApplicationPage
    {
        //Used to set the app properties
        MobileAppSettings MobilePushSettings = new MobileAppSettings();
        //Create an notification channel object to hold channel
        HttpNotificationChannel TopCarrotPushChannel;
        //Holds the name of Top Carrot Mobiles push channel
        string ChannelName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="NameOfChannel"></param>
        public MobilePushChannelUtilities(string NameOfChannel)
        {
            ChannelName = NameOfChannel;

        }
        /// <summary>
        /// 
        /// </summary>
        public void StartPushNotifications()
        {

            //Try to find an existing channel
            TopCarrotPushChannel = HttpNotificationChannel.Find(ChannelName);


            if (TopCarrotPushChannel == null)
            {
                TopCarrotPushChannel = new HttpNotificationChannel(ChannelName);
                //Open the channel
                TopCarrotPushChannel.Open();
                //Register events and bind to shell toast and tile toast
                RegisterPushNotificationEvents();

            }
            else
            {

                // Display the URI for testing purposes. Normally, the URI would be passed back to your web service at this point.
                System.Diagnostics.Debug.WriteLine(TopCarrotPushChannel.ChannelUri.ToString());
                MessageBox.Show(String.Format("Channel Uri is {0}", TopCarrotPushChannel.ChannelUri.ToString()));

                //Register events and bind to shell toast and tile toast
                RegisterPushNotificationEvents();

                //Update the application settings with channel Uri
                //App.PushChannelUri = TopCarrotPushChannel.ChannelUri.ToString();

            }
        }

        void TopCarrotPushChannel_HttpNotificationReceived(object sender, HttpNotificationEventArgs e)
        {
            throw new NotImplementedException();
        }

        void TopCarrotPushChannel_ConnectionStatusChanged(object sender, NotificationChannelConnectionEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {

                switch (e.ConnectionStatus.ToString())
                {
                    case "Disconnected":
                        MobilePushSettings.IsPushChannelConneted = false;
                        break;
                    case "Connected":
                        MobilePushSettings.IsPushChannelConneted = true;
                        break;
                }

            });
        }

        void TopCarrotPushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            

            Dispatcher.BeginInvoke(() =>
            {
                MobilePushSettings.PushChannelUri = e.ChannelUri.AbsoluteUri.ToString();
                // Display the new URI for testing purposes.   Normally, the URI would be passed back to your web service at this point.
                // System.Diagnostics.Debug.WriteLine(e.ChannelUri.ToString());
                MessageBox.Show(String.Format("Channel Uri is {0}", e.ChannelUri.ToString()));
            });
        }

        void TopCarrotPushChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            //Debug.WriteLine("**** Failed channel registration:  " + e.ToString());
            // Error handling logic for your particular application would be here.
            Dispatcher.BeginInvoke(() =>
                MessageBox.Show(String.Format("A push notification {0} error occurred.  {1} ({2}) {3}",
                    e.ErrorType, e.Message, e.ErrorCode, e.ErrorAdditionalData)));
        }

        void TopCarrotPushChannel_ShellToastNotificationReceived(object sender, NotificationEventArgs e)
        {
            StringBuilder message = new StringBuilder();
            string relativeUri = string.Empty;

            message.AppendFormat("Received Toast {0}:\n", DateTime.Now.ToShortTimeString());

            // Parse out the information that was part of the message.
            foreach (string key in e.Collection.Keys)
            {
                message.AppendFormat("{0}: {1}\n", key, e.Collection[key]);

                if (string.Compare(
                    key,
                    "wp:Param",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.CompareOptions.IgnoreCase) == 0)
                {
                    relativeUri = e.Collection[key];
                }
            }

            // Display a dialog of all the fields in the toast.
            Dispatcher.BeginInvoke(() => MessageBox.Show(message.ToString()));

        }

        void RegisterPushNotificationEvents()
        {
            //Register far all events before opening the channel
            TopCarrotPushChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(TopCarrotPushChannel_ChannelUriUpdated);
            TopCarrotPushChannel.ErrorOccurred += new EventHandler<NotificationChannelErrorEventArgs>(TopCarrotPushChannel_ErrorOccurred);
            TopCarrotPushChannel.ConnectionStatusChanged += new EventHandler<NotificationChannelConnectionEventArgs>(TopCarrotPushChannel_ConnectionStatusChanged);
            TopCarrotPushChannel.HttpNotificationReceived += new EventHandler<HttpNotificationEventArgs>(TopCarrotPushChannel_HttpNotificationReceived);
            //Register for notification so that the application recieves notifications while running
            TopCarrotPushChannel.ShellToastNotificationReceived += new EventHandler<NotificationEventArgs>(TopCarrotPushChannel_ShellToastNotificationReceived);

            if (!TopCarrotPushChannel.IsShellToastBound)
            {
                //Bind to channel for toast events
                TopCarrotPushChannel.BindToShellToast();
            }
            if (!TopCarrotPushChannel.IsShellTileBound)
            {
                //Bind to channel for tile toast events
                TopCarrotPushChannel.BindToShellTile();
            }
        }
    }
    /// <summary>
    /// This class is used to hold the device information data.
    /// </summary>
    /// <remarks></remarks>
    public class DeviceInfo : ObservableCollection<PhoneData>
    {
        public DeviceInfo() : base()
        {
            Add(new PhoneData("Device :", DeviceStatus.DeviceName.ToString()));
            Add(new PhoneData("Manufacture: ", DeviceStatus.DeviceManufacturer.ToString()));
        }
    }
    /// <summary>
    /// Used to hold the configuration data from a users device
    /// </summary>
    public class PhoneData
    {
        private string _label;
        private string _PhoneData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="PhoneDataType"></param>
        public PhoneData(string Label, string PhoneDataType)
        {
            this._label = Label;
            this._PhoneData = PhoneDataType;
        }
        /// <summary>
        /// Used to identify the field data type from device status
        /// </summary>
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneValues
        {
            get
            {
                return _PhoneData;
            }
            set
            {
                _PhoneData = value;
            }
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class TopCarrotConfig
    {
        IsolatedStorageSettings CurrentIsoStorAppSettings;
        /// <summary>
        /// Constructor for TopCarrotConfig class
        /// </summary>
        public TopCarrotConfig()
        {
            //Create a isolated storage settings variable
            CurrentIsoStorAppSettings = IsolatedStorageSettings.ApplicationSettings;
        }

        public static bool IsAppConfiguredWithSettings()
        {
            //Setup the return flag
            Boolean IsAppSetup = false;


            //Check for the database
            IsAppSetup = IsDatabaseCreated();
            //Now check the for the application settings
            //MobileAppSettings TopCarrotAppSettings = new MobileAppSettings();
            // IsAppSetup = TopCarrotAppSettings.AreAppDefaultSettingsReady();


            return IsAppSetup;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Boolean IsDatabaseCreated()
        {

            //Create a boolean flag to set and return to the app
            bool DbExist = false;
            //Check to see if the Db file exist
            using (MobileDatabaseContext TopCarrotLocalDb =
                new MobileDatabaseContext(MobileDatabaseContext.LocalDbConnectionString))
            {
                if (!TopCarrotLocalDb.DatabaseExists())
                {
                    TopCarrotLocalDb.CreateDatabase();
                    DbExist = true;
                }
                else
                {
                    //Set the flag to true
                    DbExist = true;
                }
            }

            return DbExist;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool ShowAppTerms()
        {
            bool TermsAccepted = false;
            IsolatedStorageSettings.ApplicationSettings.TryGetValue<bool>("TermsAccepted", out TermsAccepted);
            if (!TermsAccepted)
            {
                //Navigate to the terms page
                //NavigationService
            }
            else
            {
                TermsAccepted = true;
            }

            return TermsAccepted;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static bool IsNetworkUp()
        {
            //Setup the variables for the networking test
            bool IsNetGood = false;
            if (DeviceNetworkInformation.IsCellularDataEnabled || DeviceNetworkInformation.IsWiFiEnabled)
            {
                if (DeviceNetworkInformation.IsNetworkAvailable)
                {
                    IsNetGood = true;
                }
                else
                {
                    MessageBox.Show("WiFi or cellular data is enabled but the networ is unreachable",
                                    "Network Information", MessageBoxButton.OK);
                }

            }
            else
            {
                MessageBox.Show("Please enable cellular data or WiFi", "Network Information",
                                 MessageBoxButton.OK);
            }

            return IsNetGood;
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class BackgroundTasksConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RunBackgroundTask">If the background task should run or not</param>
        public static void ConfigureBackGroundTaskForMode(bool RunBackgroundTask)
        {
            //Setup the application
            if (TopCarrotConfig.IsAppConfiguredWithSettings())
            {
                if (RunBackgroundTask)
                {
                    //Setup background task configuration
                    ConfigureLocationService();
                }
                else
                {
                    RemoveOrPauseBackgroundTask();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        static void ConfigureLocationService()
        {
            //Background periodicTask configuration name
            string TopCarrotLocationServiceName = "TopCarrotTaskService";
            //Lets check to see that the location services are still set to run in the backgraound
            PeriodicTask TopCarrotLocationServicePeriodicTask;
            //Locate the background service by name so we can check to see if it is enabled
            TopCarrotLocationServicePeriodicTask = ScheduledActionService.Find(TopCarrotLocationServiceName) as PeriodicTask;
            //If we find the task we need to remove it so we can change the details
            if (TopCarrotLocationServicePeriodicTask != null)
            {
                ScheduledActionService.Remove(TopCarrotLocationServiceName);
            }

            //Recreate the periodic task to be added
            TopCarrotLocationServicePeriodicTask = new PeriodicTask(TopCarrotLocationServiceName);
            //Set the description for the background service
            TopCarrotLocationServicePeriodicTask.Description = "The Top Carrot location service helps identify locations" +
                " that you are frequently in and uses those locations as possible shopping areas";
            //TopCarrotLocationServicePeriodicTask.BeginTime = DateTime.Now.AddMinutes(2);
            TopCarrotLocationServicePeriodicTask.ExpirationTime = DateTime.Now.AddDays(14);
            try
            {
                ScheduledActionService.Add(TopCarrotLocationServicePeriodicTask);
                ScheduledActionService.LaunchForTest(TopCarrotLocationServiceName, TimeSpan.FromSeconds(60));
            }
            catch
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        static void RemoveOrPauseBackgroundTask()
        {
            //Background periodicTask configuration name
            string TopCarrotLocationServiceName = "TopCarrotTaskService";
            //Lets check to see that the location services are still set to run in the backgraound
            PeriodicTask TopCarrotLocationServicePeriodicTask;
            //Locate the background service by name so we can check to see if it is enabled
            TopCarrotLocationServicePeriodicTask = ScheduledActionService.Find(TopCarrotLocationServiceName) as PeriodicTask;
            //If we find the task we need to remove it so we can change the details
            if (TopCarrotLocationServicePeriodicTask != null)
            {
                ScheduledActionService.Remove(TopCarrotLocationServiceName);
            }
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class UserInputUtilities
    {
        public static bool IsPluCode(string UserInput)
        {
            bool IsPluCode = false;
            int PluNumber = 0;

            if (Int32.TryParse(UserInput, out PluNumber))
            {
                IsPluCode = true;
            }

            return IsPluCode;
        }

        public static bool IsCropNumber(string UserInput)
        {
            bool IsCropNumber = false;

            if (UserInput.StartsWith("#"))
            {
                IsCropNumber = true;
            }

            return IsCropNumber;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MobileIndicators : PhoneApplicationPage
    {
        public void ShowProgress(DependencyObject CurrentPage)
        {
            ProgressIndicator ProgBar = new ProgressIndicator();

            //Setup the system tray on the window to hold he progress bar
            SystemTray.SetIsVisible(CurrentPage, true);
            SystemTray.SetOpacity(CurrentPage, 0); //This opacity keeps the page layout from changing when displayed

            //Set the properties on the progress bar
            ProgBar.IsIndeterminate = true;
            ProgBar.IsVisible = true;

            //Add the progress bar to the system tray
            SystemTray.SetProgressIndicator(CurrentPage, ProgBar);

        }

        public void HideProgress(DependencyObject CurrentPage)
        {
            //
            ProgressIndicator ProgBar = SystemTray.ProgressIndicator;
            //Set the properties on the progress bar
            ProgBar.IsIndeterminate = false;
            ProgBar.IsVisible = false;

            //Add the progress bar to the system tray
            SystemTray.SetProgressIndicator(CurrentPage, null);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class BingMapsXmlProcessing
    {
        private string _Name;

        public BingMapsXmlProcessing()
        {
        }

        [XmlElementAttribute(ElementName="Name")]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

    }
}
    