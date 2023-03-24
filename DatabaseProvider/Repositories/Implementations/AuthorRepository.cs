using Core.Models;
using DatabaseProvider.Repositories.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseProvider.Repositories.Implementations
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationContext context)
            : base(context)
        {
        }

        public List<Author> GetAll()
        {
            return Entities.ToList();
        }

        public Author GetById(int id)
        {
            return Entities.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
