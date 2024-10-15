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
                if (ex is not TargetInvocationException tiex)
                {
                    return ex;
                }

                ex = tiex.InnerException!;
            }
        }
    }
}
