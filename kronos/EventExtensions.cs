namespace Kronos;

using System;

internal static class EventExtensions
{
    /// <exception cref="T:System.Exception">A delegate callback throws an exception.</exception>
    public static void RaiseEvent(this EventHandler @event, object sender, EventArgs e)
    {
        @event?.Invoke(sender, e);
    }

    /// <exception cref="T:System.Exception">A delegate callback throws an exception.</exception>
    public static void RaiseEvent<T>(this EventHandler<T> @event, object sender, T e) where T : EventArgs
    {
        @event?.Invoke(sender, e);
    }
}