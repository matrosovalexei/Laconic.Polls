using System.Threading.Tasks;
using Laconic.Polls.Domain.Entities;

namespace Laconic.Polls.Domain.Data
{
    public interface IDataSet<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> FindAsync(int id);
        void Add(TEntity entity);
    }
}