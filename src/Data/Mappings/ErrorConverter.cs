using System;
using Spoofi.FreudBot.Data.Entities;

namespace Spoofi.FreudBot.Data.Mappings
{
    public static class ErrorConverter
    {
        public static Error Convert(this Exception source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return new Error
            {
                Date = DateTime.Now.ToUniversalTime(),
                Message = source.Message,
                Stacktrace = source.StackTrace
            };
        }
    }
}