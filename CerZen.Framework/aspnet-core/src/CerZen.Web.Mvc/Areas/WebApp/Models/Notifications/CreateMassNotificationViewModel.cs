using System.Collections.Generic;
using Abp.Notifications;

namespace CerZen.Web.Areas.WebApp.Models.Notifications
{
    public class CreateMassNotificationViewModel
    {
        public List<string> TargetNotifiers { get; set; }
    
        public NotificationSeverity Severity { get; set; }
    }
}