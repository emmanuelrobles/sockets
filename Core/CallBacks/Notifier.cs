using System;

namespace Core.CallBacks
{
    public abstract class Notifier <T>
    {
        public string Identifier { get; private set; }
        public Action<T> CallBack { get; private set; }

        protected Notifier(string identifier, Action<T> callBack)
        {
            Identifier = identifier;
            CallBack = callBack;
        }
    }
}