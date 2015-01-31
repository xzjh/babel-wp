using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Babel
{
    class ResponseParser
    {
        private Dictionary<string, string> ParseResponse(string parameters)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameters);

            return result;
        }

        private void ParseUser(string parameters, User user)
        {
            Dictionary<string, string> result = ParseResponse(parameters);
            user.UserName = result["username"];
            user.Password = result["password"];
            user.UserIntroduction = result["status"];
            user.UserDescription = result["description"];
            user.UserIconUrl = result["image"];
            user.UserFacebookUrl = result["Facebook"];
        }

        private void ParseActivity(string parameters, Activity ac)
        {
            Dictionary<string, string> result = ParseResponse(parameters);
            ac.ActivityTitle = result["title"];
            ac.Description = result["description"];
            ac.Available = Convert.ToInt32(result["available"]);
            ac.Capacity = Convert.ToInt32(result["capacity"]);
            ac.Budget = Convert.ToInt32(result["price"]);
            ac.Destination = result["destination"];
            ac.LocationDetail = result["location"];
            ac.ActivityTime = Convert.ToDateTime(result["event date"]);
            ac.Owner = result["owner"];
   //         'applicants': applicants,
    //         'participants': participants
        }

        private string ParseMessage(string parameters)
        {
            Dictionary<string, string> result = ParseResponse(parameters);
            string action = result["action"];
            string events = result["events"];
            string from = result["from"];
            string to = result["to"];
            string ans = from;
            if (action == "Apply")
            {
                ans += " applies for your event - " + events + " .";
            }
            else
            {
                ans += " has accecpted for your application of event - " + events + " .";
            }
            return ans;
        }
    }
}
