using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace SMSDeliveryNotifications.Util
{
    public class BasicAuth
    {
        public static bool Authenticate(HttpRequestHeaders headers)
        {
            List<string> credentials = new List<string>();
            string cred = headers.Authorization.ToString();
            bool authenticated = false;

            string encodedUsernamePassword = cred.Substring("Basic ".Length).Trim();

            Encoding encoding = Encoding.GetEncoding("UTF-8");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

            int seperatorIndex = usernamePassword.IndexOf(':');

            credentials.Add(usernamePassword.Substring(0, seperatorIndex));
            credentials.Add(usernamePassword.Substring(seperatorIndex + 1));

            if(credentials[0] == ConfigurationManager.AppSettings["config:Username"] && 
               credentials[1] == ConfigurationManager.AppSettings["config:Password"])
            {
                authenticated = true;
            }


            return authenticated;
        }
    }
}