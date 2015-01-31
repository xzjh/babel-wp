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
    public partial class Profile : PhoneApplicationPage
    {
        User thisItem;
        public Profile()
        {
            InitializeComponent();
        }
        private void LoadUser(object sender, RoutedEventArgs e)
        {
            thisItem = App.user;
            LayoutRoot.DataContext = thisItem;
        }
    }
}