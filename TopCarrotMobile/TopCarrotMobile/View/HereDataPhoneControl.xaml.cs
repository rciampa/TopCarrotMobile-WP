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

namespace TopCarrotMobile
{
    public partial class HereDataPhoneControl : UserControl
    {
        public HereDataPhoneControl()
        {
            InitializeComponent();
            DataContext = App.HereViewModel;
        }

        private void ucHereData_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.HereViewModel.IsDataLoaded)
            {
                App.HereViewModel.LoadData();
            }
        }
    }
}
