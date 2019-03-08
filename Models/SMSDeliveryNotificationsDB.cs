namespace SMSDeliveryNotifications.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SMSDeliveryNotificationsDB : DbContext
    {
        public SMSDeliveryNotificationsDB()
            : base("name=SMSDeliveryNotificationsDB")
        {
        }

        public DbSet<Notifications> Notifications { get; set; }
    }

}