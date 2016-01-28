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
using System.ComponentModel;
using TopCarrotMobile.TopCarrotServiceReference;
using System.Linq;
using System.Data.Services.Client;

namespace TopCarrotMobile
{
    public class SearchByViewModel : INotifyPropertyChanged
    {
        // Declare the data service objects and URIs.
        private TopCarrotEntities context;
        private readonly Uri topCarrotDataUri =
            new Uri("http://odata.topcarrot.mobi:4200/TopCarrotDataService.svc/");

        IQueryable<CommodityPluCode> SearchQuery;

        public SearchByViewModel()
        {
            this.commodityPluCodes = new DataServiceCollection<CommodityPluCode>();
            context.SendingRequest += new EventHandler<SendingRequestEventArgs>(context_SendingRequest);
            context.ReadingResponse += new EventHandler<ReadingWritingHttpMessageEventArgs>(context_ReadingResponse);
        }

        /// <summary>
        /// Sets a public property of the DataServiceCollection with a name of commodityPluCodes
        /// </summary>
        public DataServiceCollection<CommodityPluCode> commodityPluCodes { get; set; }









        void context_ReadingResponse(object sender, ReadingWritingHttpMessageEventArgs e)
        {
            throw new NotImplementedException();
        }

        void context_SendingRequest(object sender, SendingRequestEventArgs e)
        {
            throw new NotImplementedException();
        }







        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
