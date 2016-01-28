using System;
using System.Windows;
using Microsoft.Phone.Controls;


namespace TopCarrotMobile
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //Set the data context for the listbox control to FavortiesViewModel
             //pItmFavorites.DataContext = App.FavViewModel;
            DataContext = App.FavViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }


        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Show the applicaiton bar
            ApplicationBar.IsVisible = true;

            if (!App.FavViewModel.IsDataLoaded)
            {
                App.FavViewModel.LoadData(); ;
            }
            
            //using (MobileDatabaseContext TopCarrotDb = new MobileDatabaseContext(MobileDatabaseContext.LocalDbConnectionString))
            //{
            //    var MyFavCommodInDb = from FavoriteCommodities MyCommod in TopCarrotDb.FavoriteCommodities
            //                      select MyCommod;

            //  ObservableCollection<FavoriteCommodities>  MyFavCommod =
            //      new ObservableCollection<FavoriteCommodities>(MyFavCommodInDb);

            //  lstFavCommodities.DataContext = MyFavCommod;
            //}

            
        }

        

        private void appBtnSearch_Click(object sender, System.EventArgs e)
        {
        	NavigationService.Navigate(new Uri("/SearchBy.xaml", UriKind.Relative));
        }

        private void menBtnAbout_Click(object sender, System.EventArgs e)
        {
        	NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void menBtnSettings_Click(object sender, System.EventArgs e)
        {
        	NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        private void menBtnHelp_Click(object sender, System.EventArgs e)
        {
        	NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }

        private void menBtnLogin_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }

    }
}