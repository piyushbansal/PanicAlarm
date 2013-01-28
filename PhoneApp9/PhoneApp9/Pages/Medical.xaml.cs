using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp9.Resources;

namespace PhoneApp9
{
    public partial class medical : PhoneApplicationPage
    {
        // Constructor
        public medical()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (StreamWriter w = File.CreateText(@"history.txt"))
            {
                w.WriteLine("Full Name   : " + name.Text);
                w.WriteLine("Blood Group : " + blood.Text);
                w.WriteLine("Any Allergies :");
                w.WriteLine(allergy.Text);
                w.WriteLine("Major Surgeries(if any) :");
                w.WriteLine(surgery.Text);
                w.Flush();
                w.Close();
            }

            using (StreamWriter w = File.CreateText(@"check"))
            {
                w.WriteLine("1");
            }
            var url = "/MainPage.xaml";
            Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri(url, UriKind.Relative)));
        }

        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {
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