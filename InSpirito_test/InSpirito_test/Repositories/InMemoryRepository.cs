using InSpirito_test.Interfaces;
using InSpirito_test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InSpirito_test.Repositories
{
    public class InMemoryRepository : IRepository
    {
        private List<Book> books = new List<Book>();
        private int lastBookId = 2;
        public InMemoryRepository()
        {
            books.Add(new Book { Id = 0, Title = "Pro ASP.NET Core MVC 2", Author = " Adam Freeman" });
            books.Add(new Book { Id = 1, Title = "CLR VIA C#", Author = "Jeffrey Richter" });
            books.Add(new Book { Id = 2, Title = "Pro C# 2010 and the .NET 4 Platform, Fifth Edition", Author = "Andrew W. Troelsen " });
        }

        public IQueryable<Book> GetAll()
        {
            return books.AsQueryable();
        }
        public Book GetById(int id)
        {
            return books.Find(x => x.Id == id);
        }
        public void Delete(int id)
        {
            Book item = books.Find(x => x.Id == id);
            books.Remove(item);
        }
        public void Add(Book entity)
        {
            entity.Id = ++lastBookId;
            books.Add(entity);
        }
        public void Update(Book entity)
        {

            Book obj = books.FirstOrDefault(x => x.Id == entity.Id);

            obj.Title = entity.Title;
            obj.Author = entity.Author;
            
        }
    }
}
