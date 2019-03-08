using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using SMSDeliveryNotifications.Models;
using System.Text;
using SMSDeliveryNotifications.Util;

namespace SMSDeliveryNotifications.Controllers
{
    public class ValuesController : ApiController
    {
        // POST api/values
        //[SwaggerOperation("Create")]
        //[SwaggerResponse(HttpStatusCode.Created)]
        public HttpResponseMessage Post([FromBody]  Notifications value)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            bool authenticated = BasicAuth.Authenticate(headers);

            if(authenticated == false)
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            var context = new SMSDeliveryNotificationsDB();
            Notifications notification = new Notifications();

            notification.uniqueid = value.number + "/" + DateTime.Now.ToString();
            notification.number = value.number;
            notification.status = value.status;
            notification.datetime = value.datetime;

            context.Notifications.Add(notification);
            context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

    }
}
