using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Device.Location;


namespace TopCarrotMobile
{
    public partial class Login : PhoneApplicationPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void menBtnHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }

        private void menBtnAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void menBtnOk_Click(object sender, EventArgs e)
        {
            //Process logon then g back to the calling page.
            this.NavigationService.GoBack();
        }

        private void menBtnCanel_Click(object sender, EventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            GeoCoordinateWatcher TopCarrotwatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            TopCarrotwatcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(TopCarrotwatcher_StatusChanged);
            TopCarrotwatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(TopCarrotwatcher_PositionChanged);
            TopCarrotwatcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
        }

        void TopCarrotwatcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            textBlock3.Text += e.Position.Location.ToString();
        }

        void TopCarrotwatcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    textBlock3.Text += "Dis ";
                    break;
                case GeoPositionStatus.Initializing:
                    textBlock3.Text += "Init ";
                    break;
                case GeoPositionStatus.NoData:
                    textBlock3.Text += "NoD ";
                    break;
                case GeoPositionStatus.Ready:
                    textBlock3.Text += "Ready ";
                    break;
                default:
                    break;
            }
        }


    }
}