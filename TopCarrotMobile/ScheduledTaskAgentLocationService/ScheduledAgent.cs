using System;
using System.IO;
using System.Device.Location;
using System.IO.IsolatedStorage;
using System.Net;
using System.Windows;
using System.Xml.Linq;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;

namespace ScheduledTaskAgentLocationService
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        private static volatile bool _classInitialized;
        MobileTaskAppSettings TaskAppSettings = new MobileTaskAppSettings();
        //Create the geo watcher
        GeoCoordinateWatcher TopCarrotwatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);

        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        public ScheduledAgent()
        {
            if (!_classInitialized)
            {
                _classInitialized = true;
                // Subscribe to the managed exception handler
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    Application.Current.UnhandledException += ScheduledAgent_UnhandledException;
                });
            }

        }

        // Code to execute on Unhandled Exceptions
        private void ScheduledAgent_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        /// <summary>
        /// Agent that runs a scheduled task
        /// </summary>
        /// <param name="task">
        /// The invoked task
        /// </param>
        /// <remarks>
        /// This method is called when a periodic or resource intensive task is invoked
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {

            //Reg a handler for the position changes event
            TopCarrotwatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(TopCarrotwatcher_PositionChanged);
            //We only know if they move mor than a mile or 50 meters
            TopCarrotwatcher.MovementThreshold = 50;
            TopCarrotwatcher.TryStart(true, TimeSpan.FromMilliseconds(2000));

            //This is for testing
            ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(60));



            //Check to see if the task is perodic or a long running task
            if (task is PeriodicTask)
            {
                //Create a variable to hold the result of network availablity call
                bool NetWorkAvaliable = false;
                NetWorkAvaliable = DeviceNetworkInformation.IsNetworkAvailable;
                //If we have an avaliable network then test the connectivity by host name resolution
                if (NetWorkAvaliable)
                {


                    do
                    {
                    } while (!TopCarrotwatcher.Position.Location.IsUnknown);

                }

                //This shuts down the backgroud task if there is no network access.
                //NotifyComplete();

            }
            else
            {
                NotifyComplete();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TopCarrotwatcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            //Setup the toast messages
            ShellToast TcBgToast = new ShellToast();
            TcBgToast.Title = "Location";
            TcBgToast.Content = e.Position.Location.ToString();
            TcBgToast.Show();

            //Get the geocode data from bing
            GetReverseGeoData(e.Position.Location.Latitude.ToString(), e.Position.Location.Longitude.ToString());

            //Stop the watcher since we now have the data point we need.
            TopCarrotwatcher.Stop();

            //NotifyComplete();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Latitude"></param>
        /// <param name="Longitude"></param>
        void GetReverseGeoData(string Latitude, string Longitude)
        {
            MobileTaskAppSettings TaskAppSettings = new MobileTaskAppSettings();
            //Set Bing Maps key
            string BingMapsKey = TaskAppSettings.BingMapKey;
            string BingMapUriBase = TaskAppSettings.BingMapBaseUri;
            string RequestXmlUri = String.Format(BingMapUriBase + Latitude + "," + Longitude + "?o=xml&key={0}",BingMapsKey);

            WebClient GeoRequest = new WebClient();
            GeoRequest.DownloadStringCompleted += new DownloadStringCompletedEventHandler(GeoRequest_DownloadStringCompleted);
            GeoRequest.DownloadStringAsync(new Uri(RequestXmlUri));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GeoRequest_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                XElement OdataResponce = XElement.Parse(e.Result.ToString());
 
                UpdateDatabase(OdataResponce);
            }
            else
            {
                NotifyComplete();
            }
        }
        /// <summary>
        /// Extracts values from the recived oData feed and updates the users local database. If web services are
        /// enabled on the users device the Top Carrot cloud service is updated also
        /// </summary>
        /// <param name="oData">Holds the location address information from Bing Maps</param>
        void UpdateDatabase(XElement oData)
        {
            //Extract the postal code from the xml responce as a string
            //string Zip = oData.Element("PostalCode").Value.ToString();

            NotifyComplete();
        }
    }
}