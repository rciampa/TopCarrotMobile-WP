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
using Microsoft.Phone.Shell;
using TopCarrotMobile.TopCarrotServiceReference;
using System.Data.Services.Client;
using TopCarrotMobile.AppCode;

namespace TopCarrotMobile
{
    public partial class SearchByPlu : PhoneApplicationPage
    {
        public SearchByPlu()
        {
            InitializeComponent();

        }
       
        // Declare the data service objects and URIs.
        private TopCarrotEntities context;
        private readonly Uri topCarrotDataUri =
            new Uri("http://odata.topcarrot.mobi:4200/TopCarrotDataService.svc/");
        private DataServiceCollection<CommodityPluCode> commodityPluCodes;
        IQueryable<CommodityPluCode> SearchQuery;


        //Setup indicators
        MobileIndicators pageIndicators = new MobileIndicators();

        private void lstSearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             CommodityPluCode SelectedItem = (CommodityPluCode)e.AddedItems[0];

            // If selected index is -1 (no selection) do nothing
            if (lstSearchResults.SelectedIndex != -1)
            {
                // Navigate to the new page
                NavigationService.Navigate(new Uri("/DetailsPage.xaml?PluId=" + SelectedItem.PLUId.ToString() , UriKind.Relative));
            }
        }

        private void btnFindCommodity_Click(object sender, RoutedEventArgs e)
        {
            // Initialize the context and the binding collection 
            context = new TopCarrotEntities(topCarrotDataUri);
            context.SendingRequest += new EventHandler<SendingRequestEventArgs>(context_SendingRequest);
            commodityPluCodes = new DataServiceCollection<CommodityPluCode>(context);
            //Show the progress bar
            pageIndicators.ShowProgress(this);  


            if (UserInputUtilities.IsPluCode(txtCommodityToFind.Text))
            {
                txtblkInstructions.Text = "By PLU code entered";
                SearchQuery = from CommodityPluCode PluData in context.CommodityPluCodes
                            where PluData.PLU == txtCommodityToFind.Text.ToString()
                            select PluData;
            }
            if (UserInputUtilities.IsCropNumber(txtCommodityToFind.Text))
            {
                txtblkInstructions.Text = "By crop ID entered";
                SearchQuery = from CommodityPluCode PluData in context.CommodityPluCodes
                              where PluData.Commodity == txtCommodityToFind.Text.ToUpper()
                              select PluData;
            }
            else
            {
                txtblkInstructions.Text = "By commondity name entered";
                SearchQuery = from CommodityPluCode PluData in context.CommodityPluCodes
                            where PluData.Commodity == txtCommodityToFind.Text.ToUpper()
                            select PluData;
            }

            // Register for the LoadCompleted event.
            commodityPluCodes.LoadCompleted
               += new EventHandler<LoadCompletedEventArgs>(commodityPluCodes_LoadCompleted);


            // Load the customers feed by executing the LINQ query.
            commodityPluCodes.LoadAsync(SearchQuery);

        }

        void context_SendingRequest(object sender, SendingRequestEventArgs e)
        {
            txtblkInstructions.Text += " : Sending..";
        }

        void commodityPluCodes_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            //
            pageIndicators.HideProgress(this);

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
            }
            else
            {
                MessageBox.Show(string.Format("An error has occurred: {0}", e.Error.Message));
            }
        }

        private void menBtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void menBtnCancel_Click(object sender, EventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void SearchPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


    }
}