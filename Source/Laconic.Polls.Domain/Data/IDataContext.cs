using System.Threading.Tasks;
using Laconic.Polls.Domain.Entities;

namespace Laconic.Polls.Domain.Data
{
    public interface IDataContext
    {
        IDataSet<Poll> Polls { get; }
        IDataSet<Option> Options { get; }
        IDataSet<Vote> Votes { get; }
        Task SaveChangesAsync();
    }
}