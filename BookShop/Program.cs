using Core.Models;
using DatabaseProvider;
using DatabaseProvider.Repositories.Abstractions;
using DatabaseProvider.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookShop
{
    public class Program
    {
        private const string ConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Books;Pooling=true;Integrated Security=SSPI";

        private static ApplicationContext _applicationContext;
        private static IAuthorRepository _authorRepository;
        private static IBookRepository _bookRepository;
                
        public static void Main(string[] args)
        {
            _applicationContext = new ApplicationContext(ConnectionString);
            _authorRepository = new AuthorRepository(_applicationContext);
            _bookRepository = new BookRepository(_applicationContext);

            ProcessCommands();
        }

        public static void ProcessCommands()
        {            
            while (true)
            {
                Console.Write("Enter command: ");
                string[] commandLine = Console.ReadLine().Split(' ');
                string command = commandLine[0];
                List<string> parameters = commandLine.Skip(1).ToList();
                switch (command)
                {
                    case "exit":
                        return;
                    case "add-author":
                        AddAuthor(parameters);
                        break;
                    case "add-book":
                        AddBook(parameters);
                        break;
                    case "delete-author":
                        DeleteAuthor(parameters);
                        break;
                    case "delete-book":
                        DeleteBook(parameters);
                        break;
                    case "list-books":
                        ListBooks();
                        break;
                    case "list-books-by-author":
                        ListBooksByAuthor(parameters);
                        break;
                    case "list-authors":
                        ListAuthors();
                        break;
                }
            }
        }

        public static void AddAuthor(List<string> parameters)
        {
            Author author = new Author
            {
                Name = parameters[0]
            };
            _authorRepository.Add(author);
            _authorRepository.SaveChanges();
        }

        public static void AddBook(List<string> parameters)
        {
            string title = parameters[0];
            int authorId = int.Parse(parameters[1]);
            Author author = _authorRepository.GetById(authorId);
            Book book = new Book
            {
                Title = title,
                Author = author
            };
            _bookRepository.Add(book);
            _bookRepository.SaveChanges();
        }

        public static void DeleteAuthor(List<string> parameters)
        {
            int authorId = int.Parse(parameters[0]);
            Author author = _authorRepository.GetById(authorId);
            _authorRepository.Remove(author);
            _authorRepository.SaveChanges();
        }

        public static void DeleteBook(List<string> parameters)
        {
            int bookId = int.Parse(parameters[0]);
            Book book = _bookRepository.GetById(bookId);
            _bookRepository.Remove(book);
            _bookRepository.SaveChanges();
        }

        public static void ListBooks()
        {
            foreach (var book in _bookRepository.GetAll())
            {
                Console.WriteLine(book);
            }
        }

        public static void ListBooksByAuthor(List<string> parameters)
        {
            int authorId = int.Parse(parameters[0]);
            foreach (var book in _bookRepository.GetByAuthorId(authorId))
            {
                Console.WriteLine(book);
            }
        }

        public static void ListAuthors()
        {
            foreach (var author in _authorRepository.GetAll())
            {
                Console.WriteLine(author);
            }
        }
    }
}
