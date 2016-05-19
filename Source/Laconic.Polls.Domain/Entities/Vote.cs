using System;

namespace Laconic.Polls.Domain.Entities
{
    public class Vote : Entity
    {
        public DateTimeOffset Taken { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual Option Option { get; set; }
    }
}