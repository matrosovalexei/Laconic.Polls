using System;
using System.Collections.Generic;

namespace Laconic.Polls.Domain.Entities
{
    public class Poll : Entity
    {
        public string Question { get; set; }
        public DateTimeOffset Created { get; set; }

        public virtual IList<Option> Options { get; set; }
        public virtual IList<Vote> Votes { get; set; }
    }
}