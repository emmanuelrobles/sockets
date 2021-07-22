using System;
using JsonCallBacks.BaseCallBacks;
using JsonCallBacks.Models.Notifications;

namespace JsonCallBacks.JsonNotification
{
    public class SystemPropertiesNotification : JsonNotifier<SystemProperties>
    {
        public SystemPropertiesNotification(Action<SystemProperties> callBack) : base("systemProperties", callBack)
        {
        }
    }
}