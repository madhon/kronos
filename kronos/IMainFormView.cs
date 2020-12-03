namespace Kronos
{
    using System;

    internal interface IMainFormView : IView
    {
        event EventHandler? AddActivity;

        string Activity { get; set; }

        string ActivityLog { get; set; }

        string Time { get; set; }
    }
}