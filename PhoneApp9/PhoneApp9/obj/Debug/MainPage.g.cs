﻿#pragma checksum "C:\Users\woa\Documents\Visual Studio 2012\Projects\PhoneApp9\PhoneApp9\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "505858BFDE45CC5D2A40BAFAEB701889"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
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


namespace PhoneApp9 {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock Title;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Shapes.Ellipse Panic_Button;
        
        internal System.Windows.Controls.Button Hospitals;
        
        internal System.Windows.Controls.Button Important_Contacts;
        
        internal System.Windows.Controls.Button Police_Stations;
        
        internal System.Windows.Controls.Button Pharmacy;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhoneApp9;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.Title = ((System.Windows.Controls.TextBlock)(this.FindName("Title")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.Panic_Button = ((System.Windows.Shapes.Ellipse)(this.FindName("Panic_Button")));
            this.Hospitals = ((System.Windows.Controls.Button)(this.FindName("Hospitals")));
            this.Important_Contacts = ((System.Windows.Controls.Button)(this.FindName("Important_Contacts")));
            this.Police_Stations = ((System.Windows.Controls.Button)(this.FindName("Police_Stations")));
            this.Pharmacy = ((System.Windows.Controls.Button)(this.FindName("Pharmacy")));
        }
    }
}

