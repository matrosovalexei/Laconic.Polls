using System;

namespace Laconic.Polls.Domain.Tools
{
    public interface IClock
    {
        DateTimeOffset Now { get; }
    }

    public class Clock : IClock
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}