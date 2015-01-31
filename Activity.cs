using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel
{
    public class Activity
    {
        public Activity() { }
        public Activity(string title)
        {
            this.ActivityTitle = title;
        }
        public string ActivityId { get; set; }
        public string ActivityTitle { get; set; }
        public DateTime ActivityTime { get; set; }
        public int Capacity {get; set;}
        public int Available { get; set;}
        public int Budget { get; set; }//0 for free; 1 for 0-10; 2 for 10-20; 3 for 20 - 50; 4 for over 50; 5 for Not sure
        public int LocationIndex { get; set; }//
        public string LocationDetail { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
    }
}
