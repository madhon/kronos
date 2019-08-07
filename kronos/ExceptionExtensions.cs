namespace Kronos
{
    using System;
    using System.Reflection;

    internal static class ExceptionExtensions
    {
        public static Exception UnWrap(this Exception ex)
        {
            while (true)
            {
                var tiex = ex as TargetInvocationException;
                if (tiex == null)
                    return ex;

                ex = tiex.InnerException;
            }
        }
    }
}
