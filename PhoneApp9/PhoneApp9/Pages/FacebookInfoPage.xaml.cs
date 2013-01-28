using System;
using System.IO;
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
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using Facebook;
using sdkMapControlWP8CS;
using sdkMapControlWP8CS.Resources;

namespace PhoneApp9.Pages
{
    public partial class FacebookInfoPage : PhoneApplicationPage
    {
        sdkmap sdk;
        string final_image;
        string final_xml;
        private string _accessToken;
        private string _userId;

        public FacebookInfoPage()
        {
            sdk = new sdkmap();
            //sdk.GetLocation();
            sdk.ShowMyLocationOnTheMap2();
        
            InitializeComponent();
        }

        public void make_string_for_image()
        {
            //StreamReader streamReader = new StreamReader(@"coord.txt");
            //string var = streamReader.ReadLine();
            string coordinates = "47.64054,-122.12934";
            string mess = "\nHere is the link to my location on the map" + " ";
            string ini = "http://dev.virtualearth.net/REST/v1/Imagery/Map/Road/";
            string middle = "/13?&pp=";
            string end = "&mapMetadata=0&key=AmvMyHEf5R349WdlK9m9xP52mO9Xktsw7OWtgAt8RRTHa2etbYwOfAagHz3buuqq";
            final_image = mess + ini + coordinates + middle + coordinates + end;
        }
        public void make_string_for_address()
        {
            //StreamReader streamReader = new StreamReader(@"coord.txt");
            //string var = streamReader.ReadLine();
            string coordinates = "47.64054,-122.12934";
            string mess = "\nHere is the link to my location address" + " ";
            string ini = "http://dev.virtualearth.net/REST/v1/Locations/";
            string end = "?o=xml&includeNeighborhood=1&key=AmvMyHEf5R349WdlK9m9xP52mO9Xktsw7OWtgAt8RRTHa2etbYwOfAagHz3buuqq";
            final_xml = mess + ini + coordinates + end;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _accessToken = NavigationContext.QueryString["access_token"];
            _userId = NavigationContext.QueryString["id"];
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFacebookData();
        }

        private void LoadFacebookData()
        {
          //  GetUserProfilePicture();

          //  GraphApiSample();

          //  FqlSample();

            Post_Without_Click();
        }

        private void GetUserProfilePicture()
        {
            // available picture types: square (50x50), small (50xvariable height), large (about 200x variable height) (all size in pixels)
            // for more info visit http://developers.facebook.com/docs/reference/api
            string profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", _userId, "square", _accessToken);

            picProfile.Source = new BitmapImage(new Uri(profilePictureUrl));
        }

        private void GraphApiSample()
        {
            var fb = new FacebookClient(_accessToken);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();

                Dispatcher.BeginInvoke(() =>
                {
                    ProfileName.Text = "Hi " + (string)result["name"];
                    FirstName.Text = "First Name: " + (string)result["first_name"];
                    FirstName.Text = "Last Name: " + (string)result["last_name"];
                });
            };

            fb.GetAsync("me");
        }

        private void FqlSample()
        {
            var fb = new FacebookClient(_accessToken);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();
                var data = (IList<object>)result["data"];

                var count = data.Count;

                // since this is an async callback, make sure to be on the right thread
                // when working with the UI.
                Dispatcher.BeginInvoke(() =>
                {
                    TotalFriends.Text = string.Format("You have {0} friend(s).", count);
                });
            };

            // query to get all the friends
            var query = string.Format("SELECT uid,pic_square FROM user WHERE uid IN (SELECT uid2 FROM friend WHERE uid1={0})", "me()");

            // Note: For windows phone 7, make sure to add [assembly: InternalsVisibleTo("Facebook")] if you are using anonymous objects as parameter.
            fb.GetAsync("fql", new { q = query });
        }

        private string _lastMessageId;
        public void PostToWall_Click(object sender, RoutedEventArgs e)
        {
        }
        public void Post_Without_Click()
        {
            sdk.ShowMyLocationOnTheMap2();
            make_string_for_address();
            make_string_for_image();
            txtMessage.Text = "";
            StreamReader streamReader = new StreamReader(@"msgfb");
            string var = streamReader.ReadLine();
            txtMessage.Text = txtMessage.Text + var + final_image + final_xml;
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                MessageBox.Show("Enter message.");
                return;
            }
            //MessageBox.Show(txtMessage.Text);


            var fb = new FacebookClient(_accessToken);

            fb.PostCompleted += (o, args) =>
            {
                if (args.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(args.Error.Message));
                    return;
                }

                var result = (IDictionary<string, object>)args.GetResultData();
                _lastMessageId = (string)result["id"];
                
                Dispatcher.BeginInvoke(() =>
                {
                   // MessageBox.Show("Message Posted successfully");

                    txtMessage.Text = string.Empty;
                    btnDeleteLastMessage.IsEnabled = true;
                });
            };

            var parameters = new Dictionary<string, object>();
            parameters["message"] = txtMessage.Text;

            fb.PostAsync("me/feed", parameters);
            NavigationService.Navigate(new Uri("/panic_mode.xaml", UriKind.Relative));
        }

        private void DeleteLastMessage_Click(object sender, RoutedEventArgs e)
        {
            btnDeleteLastMessage.IsEnabled = false;

            var fb = new FacebookClient(_accessToken);

            fb.DeleteCompleted += (o, args) =>
            {
                if (args.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(args.Error.Message));
                    return;
                }

                Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show("Message deleted successfully");
                    btnDeleteLastMessage.IsEnabled = false;
                });
            };

            fb.DeleteAsync(_lastMessageId);
        }
    }
}