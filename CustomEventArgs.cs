using System;

namespace SAKD
{
    public class CustomEventArgs
    {
        public delegate void OnCloseEvent(object sender, OnCloseFilterViewEventArgs args);

        public class OnCloseFilterViewEventArgs : EventArgs
        {
            public bool IsApplied { get; set; }
        }
    }
}
