using Core.Models;
using System.Collections.Generic;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IAuthorRepository : IRepository<Author>
    {
        public List<Author> GetAll();
        public Author GetById(int id);
    }
}
