namespace Kronos
{
    using System;

    internal class Presenter<TView> where TView : class, IView
    {
        public Presenter(TView view)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
            View.Initialize += OnViewInitialize;
            View.Load += OnViewLoad;
        }

        public TView View { get; set; }

        protected virtual void OnViewInitialize(object? sender, EventArgs e) 
        { 
        }

        protected virtual void OnViewLoad(object? sender, EventArgs e) 
        {
        }
    }
}