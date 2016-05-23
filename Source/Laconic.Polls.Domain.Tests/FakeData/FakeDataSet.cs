using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laconic.Polls.Domain.Data;
using Laconic.Polls.Domain.Entities;

namespace Laconic.Polls.Domain.Tests.FakeData
{
    public class FakeDataSet<TEntity> : IDataSet<TEntity>
        where TEntity : Entity
    {
        private readonly List<TEntity> _entities;

        public FakeDataSet(List<TEntity> entities)
        {
            _entities = entities;
        }

        public Task<TEntity> FindAsync(int id)
        {
            return Task.FromResult(_entities.FirstOrDefault(x => x.Id == id));
        }

        public void Add(TEntity entity)
        {
            entity.Id = _entities.Count > 0 ? _entities.Max(x => x.Id) + 1 : 1;

            _entities.Add(entity);
        }
    }
}