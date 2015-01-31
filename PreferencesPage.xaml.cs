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
    public partial class PreferencesPage : PhoneApplicationPage
    {
        public User thisItem;
        public PreferencesPage()
        {
            InitializeComponent();
        }
        private void LoadPreferences(object sender, RoutedEventArgs e)
        {
            thisItem = App.user;
            LayoutRoot.DataContext = thisItem;
        }
        private void mnuCancel_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
        private void mnuOk_Click(object sender, EventArgs e)
        {
            App.user.UserDescription = txbUserDescription.Text;
            App.user.UserIntroduction = txbUserIntroduction.Text;
            //这里要把信息提交上去
            //判断是否成功
            NavigationService.GoBack();
        }
    }
}