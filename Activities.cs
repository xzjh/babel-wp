using System;
using System.Net;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows;
namespace Babel
{
    public class Activities
    {
        public Activities()
        {
            this.ActivitiesList = new ObservableCollection<Activity>();
        }
        public ObservableCollection<Activity> ActivitiesList { get; set; }
    }
}
