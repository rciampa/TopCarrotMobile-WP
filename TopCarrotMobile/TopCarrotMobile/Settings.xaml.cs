using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace TopCarrotMobile
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();

            
        }


        private void sldrNotificationLevel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (txtblkNotificationLevel != null)
            {
                if (e.NewValue > 15)
                    txtblkNotificationLevel.Text = "Notification level: All";
                else if (e.NewValue > 10)
                    txtblkNotificationLevel.Text = "Notification level: Most";
                else if (e.NewValue > 5)
                    txtblkNotificationLevel.Text = "Notification level: Some";
                else
                    txtblkNotificationLevel.Text = "Notification level: Food Saftey Only";
            }
                
        }

        private void menBtnSettingsHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SettingsHelp.xaml", UriKind.Relative));
        }

        private void appBtnDone_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
