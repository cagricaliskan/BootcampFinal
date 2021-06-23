using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.ViewModels
{
    public class NotificationViewModel
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public NotificationType NotificationType { get; set; }

        public string SerializeNotification()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static NotificationViewModel GetNotificationFromJson(string notificationJson)
        {
            return JsonConvert.DeserializeObject<NotificationViewModel>(notificationJson);
        }
    }


    public enum NotificationType
    {
        success,
        info,
        warning,
        danger
    }
}
