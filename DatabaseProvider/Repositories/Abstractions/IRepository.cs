namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IRepository<TEntity> : IAddRepository<TEntity>, IRemoveRepository<TEntity>
        where TEntity : class
    {
        public void SaveChanges();
    }
}
