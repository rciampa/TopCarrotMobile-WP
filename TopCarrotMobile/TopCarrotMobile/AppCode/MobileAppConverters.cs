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
using System.Windows.Data;

namespace TopCarrotMobile.AppCode
{
    public class MobileAppConverters
    {

    }

    public class NotificationSliderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Get the value from the value object in this case an int
            int SliderValue = 0;
            // Retrieve the format string and use it to format the value.
            string formatString = parameter as string;
            //Get the int into a usable data type for our usage
            int.TryParse(value.ToString(), out SliderValue);

            if(SliderValue > 75)
                return string.Format(culture, formatString, "4 Notifications");
            else if (SliderValue > 50)
                return string.Format(culture, formatString, "3 Notifications");
            else if(SliderValue > 25)
                return string.Format(culture, formatString, "2 Notifications");
            else
                return string.Format(culture, formatString, "Food safty only");
            

        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
