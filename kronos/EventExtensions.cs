namespace Kronos
{
    using System;

    internal static class EventExtensions
    {
        public static void RaiseEvent(this EventHandler @event, object sender, EventArgs e)
        {
            @event?.Invoke(sender, e);
        }

        public static void RaiseEvent<T>(this EventHandler<T> @event, object sender, T e) where T : EventArgs
        {
            @event?.Invoke(sender, e);
        }
    }
}