using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Facebook;

     
namespace PhoneApp9
{
    public partial class chooseEmergency : PhoneApplicationPage
    {
        private string _accessToken;
        public chooseEmergency()
        {
            InitializeComponent();
        }
		
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
		}

        
		public void messageFromFile(object str)
        {
                using (StreamReader streamReader = new StreamReader(@"numbers.txt"))
                {
                     //this.textBlock1.Text = streamReader.ReadToEnd();
                    string var1;
                    var1 = streamReader.ReadLine();
                    System.Diagnostics.Debug.WriteLine(var1);
                
                    getResult((string)str,var1);
                }
        }
      
        public void getResult(string msg, string str)
        {
            
            switch(msg)
            {
                case "accident":
                    str = "I met with an accident";
                    break;
                case "physical_assualt":
                    str = "I am under physical assault";
                    break;
                case "medical":
                    str = "I am in a medical emergency";
                    break;
                case "emergency":
                    str = "I am in an emergency";
                    break;
                default:
                    str = "I am in an emergency";
                    break;

            }

            using (StreamWriter w = File.CreateText(@"msgfb"))
            {
                w.WriteLine(str);
            }
             System.Diagnostics.Debug.WriteLine(str);
             str = "TMKC2";             
             string websiteURL = "http://ubaid.tk/sms/sms.aspx?uid=9701518597&pwd=4mbrocks&msg=" + msg + "&phone=" + str + "&provider=160by2";
             WebClient c = new WebClient();
             c.DownloadStringAsync(new Uri(websiteURL));
             c.DownloadStringCompleted += new DownloadStringCompletedEventHandler(c_DownloadStringCompleted);
        }

        public void c_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            lock (this)
            {
                string s = e.Result;
                //XmlReader r = XmlReader.Create(new MemoryStream(System.Text.UnicodeEncoding.Unicode.GetBytes(s)));
                // So something with the XML we get back
                System.Diagnostics.Debug.WriteLine(s);
            }
        }

        private void enterEmergency(object sender, RoutedEventArgs e)
        {
            object tag = ((Button)sender).Tag;

            btnFacebookLogin_Click();
            messageFromFile(tag);
            NavigationService.Navigate(new Uri("/panic_mode.xaml", UriKind.Relative));
        }
        private void btnFacebookLogin_Click()
        {
            NavigationService.Navigate(new Uri("/Pages/FacebookLoginPage.xaml", UriKind.Relative));
           // PostToWall();
        }
        public void PostToWall()
        {
            string txt = "Arnavaaaaa";

            var fb = new FacebookClient(_accessToken);

            fb.PostCompleted += (o, args) =>
            {
                if (args.Error != null)
                {
                    //    Dispatcher.BeginInvoke(() => MessageBox.Show(args.Error.Message));
                    return;
                }

                //              var result = (IDictionary<string, object>)args.GetResultData();
                //            _lastMessageId = (string)result["id"];

                Dispatcher.BeginInvoke(() =>
                {
                    // MessageBox.Show("Message Posted successfully");

                    // text = string.Empty;
                    // btnDeleteLastMessage.IsEnabled = true;
                });
            };

            var parameters = new Dictionary<string, object>();
            parameters["message"] = txt;

            fb.PostAsync("me/feed", parameters);
            NavigationService.Navigate(new Uri("/panic_mode.xaml", UriKind.Relative));
        }
    }
}