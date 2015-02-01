using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Data;

namespace Babel
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static User user { set; get; }
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //// Set the data context of the listbox control to the sample data
            //DataContext = App.ViewModel;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //if (!App.ViewModel.IsDataLoaded)
            //{
            //    App.ViewModel.LoadData();
            //}
        }

        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //user = new User();
            //user.UserName = "Zheng Li";
            //user.UserIntroduction = "I'm Zheng Li, the most handsome guy in the world.";
            //user.UserFacebookUrl = "https://www.facebook.com/sweeney1130?fref=ts";
            //user.UserIconUrl = "https://scontent-a-lax.xx.fbcdn.net/hphotos-prn2/t31.0-8/1077700_10200404863464677_701957100_o.jpg";
            //user.UserDescription = "The god of ACM. The god of USC. The god of Viterbi. The god of the world.";
            //NavigationService.Navigate(new Uri("/ActivityViewPage.xaml", UriKind.RelativeOrAbsolute));
        //    MessageBox.Show("hello");
        //    Helper.PostRequest("http://192.168.1.88/login", "username=adams", (response) =>
        //    {
        //        System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
        //        {
        //            MessageBox.Show(response.Cookies.ToString());
        //            foreach (Cookie cook in response.Cookies)
        //            {
        //                MessageBox.Show(cook.Value);
        //            }
        //        });
        //    });
        //    Helper.PostRequest("http://192.168.1.88/view_user", "username=adams", (response) =>
        //    {
        //        System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
        //        {
        //            MessageBox.Show(response.ToString());
        //        });
        //    });
            Activities acts = new Activities();
            acts.ActivitiesList.Add(App.ac1);
            acts.ActivitiesList.Add(App.ac2);
            acts.ActivitiesList.Add(App.ac3);
            acts.ActivitiesList.Add(App.ac4);
            lbNearbyActivities.ItemsSource = acts.ActivitiesList;
            lbUserActivities.ItemsSource = acts.ActivitiesList;
            App.acts = acts;

            //user = new User();
            //user.UserName = "Zheng Li";
            //user.UserIntroduction = "I'm Zheng Li, the most handsome guy in the world.";
            //user.UserFacebookUrl = "https://www.facebook.com/sweeney1130?fref=ts";
            //user.UserIconUrl = "https://scontent-a-lax.xx.fbcdn.net/hphotos-prn2/t31.0-8/1077700_10200404863464677_701957100_o.jpg";
            //user.UserDescription = "The god of ACM. The god of USC. The god of Viterbi. The god of the world.";
            //string 
        }
        private void btnMessages_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MessagePage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnPreference_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PreferencesPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void lbNearbyActivities_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

    }

    /// <summary>
    /// Activity.ID转化为DetaiPage页面Uri的Converter
    /// </summary>
    public class ActivityIdToDetailUri : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Int32)value == -1)     //没有项
            {
                return null;
            }
            return "/ActivityViewPage.xaml?index=" + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}