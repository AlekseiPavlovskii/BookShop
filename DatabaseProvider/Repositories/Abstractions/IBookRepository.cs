using Core.Models;
using System.Collections.Generic;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IBookRepository : IRepository<Book>
    {
        public List<Book> GetAll();
        public Book GetById(int id);
        public List<Book> GetByAuthorId(int id);
    }
}
