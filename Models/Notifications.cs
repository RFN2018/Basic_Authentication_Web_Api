using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMSDeliveryNotifications.Models
{
    public class Notifications
    {
        [Key]
        public string uniqueid { get; set; }
        public string number { get; set; }
        public string status { get; set; }
        public DateTime datetime { get; set; }

    }
}