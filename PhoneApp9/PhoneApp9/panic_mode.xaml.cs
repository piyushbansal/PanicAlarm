using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
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
    public partial class panic_mode : PhoneApplicationPage
    {
       sdkmap sdk;
        // Constructor
        public panic_mode()
        {
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

        private void medical_history(object sender, RoutedEventArgs e)
        {
            using (StreamReader streamReader = new StreamReader(@"history.txt"))
            {
                string var,var1="";
                while ((var = streamReader.ReadLine()) != null)
                {
                    if (var1 == "")
                        var1 = var+"\n";
                    else
                        var1 = var1 + var+"\n";
                }
                MessageBox.Show(var1);
            }
        }

        private void exit_panic_mode(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Enabled;
            MessageBox.Show("Emergency Managed");

            var url = "/MainPage.xaml";
            Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri(url, UriKind.Relative)));
        }

        private void contacts(object sender, RoutedEventArgs e)
        {
            using (StreamReader streamReader = new StreamReader(@"numbers.txt"))
            {
                string var, var1 = "";
                while ((var = streamReader.ReadLine()) != null)
                {
                    if (var1 == "")
                        var1 = var + "\n";
                    else
                        var1 = var1 + var + "\n";
                }
                MessageBox.Show(var1);
            }
        }

    }
}