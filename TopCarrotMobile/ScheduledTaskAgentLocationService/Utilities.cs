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
using System.Xml.Serialization;

namespace ScheduledTaskAgentLocationService
{
    public class Utilities
    {
       
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

        [XmlElementAttribute(ElementName = "Name")]
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
