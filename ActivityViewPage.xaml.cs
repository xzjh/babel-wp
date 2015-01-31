using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Babel
{
    public partial class ActivityViewPage : PhoneApplicationPage
    {
        public ActivityViewPage()
        {
            InitializeComponent();
        }
        private void LoadActivity (object sender, System.Windows.RoutedEventArgs e)
        {
            Activity activity = new Activity();
            activity.ActivityTitle = "Go to 99 Ranch";
            activity.ActivityTime = DateTime.Now;
            activity.Capacity = 5;
            activity.Available = 3;
            activity.Description = "Let's go to 99 Ranch";
            activity.Budget = 2;
            activity.LocationIndex = 2;
            activity.LocationDetail = "2139 Oak";
            activity.Destination = "99 Ranch";
            LayoutRoot.DataContext = activity;
        }
    }
}