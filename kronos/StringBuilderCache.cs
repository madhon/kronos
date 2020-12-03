// ReSharper disable InconsistentNaming
namespace Kronos
{
    using System;
    using System.Text;
    using System.Threading;

    public static class StringBuilderCache
    {
        [ThreadStatic]
        private static StringBuilder? _perThread;

        private static StringBuilder? _shared;

        private const int DefaultCapacity = 0x10;

        public static StringBuilder Get(int capacity = DefaultCapacity)
        {
            var tmp = _perThread;
            if (tmp != null)
            {
                _perThread = null!;
                tmp.Length = 0;
                return tmp;
            }

            tmp = Interlocked.Exchange(ref _shared, null!);
            if (tmp == null) return new StringBuilder(capacity);
            tmp.Length = 0;
            return tmp;
        }

        public static string GetStringAndRelease(this StringBuilder builder)
        {
            var s = builder.ToString();
            Recycle(builder);
            return s;
        }

        public static string GetStringAndRelease(this StringBuilder builder, int startIndex, int length)
        {
            var s = builder.ToString(startIndex, length);
            Recycle(builder);
            return s;
        }

        public static void Recycle(StringBuilder builder)
        {
            if (_perThread == null)
            {
                _perThread = builder;
            }
            else
            {
                Interlocked.CompareExchange(ref _shared, builder, null);
            }
        }
    }
}
