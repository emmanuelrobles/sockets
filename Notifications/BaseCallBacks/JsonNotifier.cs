using System;
using System.Text.Json;
using Core.CallBacks;

namespace JsonCallBacks.BaseCallBacks
{
    public abstract class JsonNotifier<T> : Notifier<string>
    {
        protected JsonNotifier(string identifier, Action<T> callBack) : base(identifier,
            (str) => { callBack(JsonSerializer.Deserialize<T>(str)); })
        {
        }
    }
}