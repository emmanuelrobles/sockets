using System;
using Core.Models.Notifications;
using JsonCallBacks.BaseCallBacks;

namespace JsonCallBacks.JsonNotification
{
    public class SystemPropertiesNotification : JsonNotifier<SystemProperties>
    {
        public SystemPropertiesNotification(Action<SystemProperties> callBack) : base("systemProperties", callBack)
        {
        }
    }
}