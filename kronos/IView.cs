namespace Kronos
{
    using System;

    internal interface IView
    {
        event EventHandler Initialize;

        event EventHandler Load;
    }
}