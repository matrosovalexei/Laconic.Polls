using System.Collections.Generic;

namespace Laconic.Polls.Domain.Entities
{
    public class Option : Entity
    {
        public string Statement { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual IList<Vote> Votes { get; set; }
    }
}