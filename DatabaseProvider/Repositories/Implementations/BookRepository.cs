using Core.Models;
using DatabaseProvider.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseProvider.Repositories.Implementations
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext context)
            : base(context)
        {
        }

        public List<Book> GetAll()
        {
            return Entities.Include(b => b.Author).ToList();
        }

        public List<Book> GetByAuthorId(int id)
        {
            return Entities.Include(b => b.Author).Where(b => b.AuthorId == id).ToList();
        }

        public Book GetById(int id)
        {
            return Entities.Include(b => b.Author).Where(b => b.Id == id).FirstOrDefault();
        }
    }
}
