﻿#pragma checksum "C:\Users\RichardD\Documents\Visual Studio 2012\Projects\TopCarrotMobile\TopCarrotMobile\View\HereRoadPhoneControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A921CCF601A59A5924453A09C44E8045"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls.Maps;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace TopCarrotMobile.View {
    
    
    public partial class HereRoadPhoneControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel stkpHereRoadHeader;
        
        internal System.Windows.Controls.Image imgHereRoardCountyLogo;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        internal System.Windows.Controls.TextBlock textBlock2;
        
        internal System.Windows.Controls.TextBlock textBlock3;
        
        internal System.Windows.Controls.ListBox listBox1;
        
        internal Microsoft.Phone.Controls.Maps.Map mapHereRoad;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/TopCarrotMobile;component/View/HereRoadPhoneControl.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.stkpHereRoadHeader = ((System.Windows.Controls.StackPanel)(this.FindName("stkpHereRoadHeader")));
            this.imgHereRoardCountyLogo = ((System.Windows.Controls.Image)(this.FindName("imgHereRoardCountyLogo")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock2")));
            this.textBlock3 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock3")));
            this.listBox1 = ((System.Windows.Controls.ListBox)(this.FindName("listBox1")));
            this.mapHereRoad = ((Microsoft.Phone.Controls.Maps.Map)(this.FindName("mapHereRoad")));
        }
    }
}
