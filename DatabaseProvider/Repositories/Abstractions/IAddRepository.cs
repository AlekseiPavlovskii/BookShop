using System.Collections.Generic;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IAddRepository<TEntity> where TEntity : class
    {
        public void Add( TEntity entity );
        public void Add( IEnumerable<TEntity> entities );
    }
}
