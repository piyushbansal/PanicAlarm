using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp9.Resources;
using sdkMapControlWP8CS;
using sdkMapControlWP8CS.Resources;
using ShowMyLocationOnMap;

namespace PhoneApp9
{
    public partial class MainPage : PhoneApplicationPage
    {
        sdkmap sdk;
        // Constructor
        public MainPage()
        {
            if (!File.Exists(@"check"))
            {
                //NavigationService.Navigate(new Uri("/Pages/FacebookLoginOnly.xaml", UriKind.Relative));
                var url = "/Pages/FacebookLoginOnly.xaml";
                Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri(url, UriKind.Relative)));
            }
            sdk = new sdkmap();
            sdk.ShowMyLocationOnTheMap();
            InitializeComponent();
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

        }
        public void click_hos(object sender, RoutedEventArgs e)
        {
            sdk.ExtractMethodhos();
        }

        private void click_pol(object sender, RoutedEventArgs e)
        {
            sdk.ExtractMethodpol();
        }

        private void click_phar(object sender, RoutedEventArgs e)
        {
            sdk.ExtractMethodphar();
        }

        private void enterPanicMode(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            NavigationService.Navigate(new Uri("/chooseEmergency.xaml", UriKind.Relative));

        }

        

        
        

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}