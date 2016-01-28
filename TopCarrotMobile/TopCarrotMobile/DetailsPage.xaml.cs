using System;
using System.Data.Services.Client;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using TopCarrotMobile.AppCode;
using TopCarrotMobile.TopCarrotServiceReference;

namespace TopCarrotMobile
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
            DataContext = App.DetailsViewModel;
            this.Loaded +=new RoutedEventHandler(DetailsPageView_Loaded);
        }

        MobileAppSettings tcMobileSettings = new MobileAppSettings();
        MobileIndicators ProgressBar = new MobileIndicators();
        // Declare the data service objects and URIs.
        private TopCarrotEntities context;
        private readonly Uri topCarrotDataUri = new Uri("http://odata.topcarrot.com");
        private DataServiceCollection<CommodityPluCode> commodityPluCodes;

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("PluId"))
            {
                int intPluIdToGet = 0;
                int.TryParse(this.NavigationContext.QueryString["PluId"], out intPluIdToGet);

                GetDetailInformation(intPluIdToGet);
            }
            else
            {
                ItemNotFound();
            }
            
                
        }

        void commodityPluCodes_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                // Handling for a paged data feed.
                if (commodityPluCodes.Continuation != null)
                {
                    // Automatically load the next page.
                    commodityPluCodes.LoadNextPartialSetAsync();
                }
                else
                {
                    // Set the data context of the list box control to the sample data.
                    this.LayoutRoot.DataContext = commodityPluCodes;
                }

                if (commodityPluCodes.Count < 1)
                {
                    ItemNotFound();
                }
            }
            else
            {
                MessageBox.Show(string.Format("An error has occurred: {0}", e.Error.Message));
                ItemNotFound();
                
            }

            ProgressBar.HideProgress(this);
        }

        private void menbtnAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Gets the details of the PLU or commodity that was selected on the Search By page
        /// </summary>
        /// <param name="PluId">The PLUID from the SQL table which is the same as the table ID</param>
        private void GetDetailInformation(int PluId)
        {
            // Initialize the context and the binding collection 
            context = new TopCarrotEntities(topCarrotDataUri);
            commodityPluCodes = new DataServiceCollection<CommodityPluCode>(context);

            // Define a LINQ query that returns all customers.
            var query = from CommodityPluCode PluData in context.CommodityPluCodes
                        where PluData.PLUId == PluId
                        select PluData;

            // Register for the LoadCompleted event.
            commodityPluCodes.LoadCompleted
                += new EventHandler<LoadCompletedEventArgs>(commodityPluCodes_LoadCompleted);

            // Load the customers feed by executing the LINQ query.
            commodityPluCodes.LoadAsync(query);
        }
        /// <summary>
        /// 
        /// </summary>
        void ItemNotFound()
        {
            TextBlock txtblkNotFound = new TextBlock();
            txtblkNotFound.Text = "Sorry we can't seem to find anything on the item you requested";
            txtblkNotFound.Width = 450;
            txtblkNotFound.Height = 200;
            txtblkNotFound.TextWrapping = TextWrapping.Wrap;
            txtblkNotFound.TextAlignment = TextAlignment.Center;
            txtblkNotFound.FontSize = 32.0;
            ContentPanel.Children.Add(txtblkNotFound);
            //Disable the add to favorites button
            ApplicationBar.IsVisible = false;
        }

        private void DetailsPageView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.DetailsViewModel.IsDataLoaded)
            {
                ProgressBar.ShowProgress(this);
                App.DetailsViewModel.LoadData();
            }
            
        }
    }
}