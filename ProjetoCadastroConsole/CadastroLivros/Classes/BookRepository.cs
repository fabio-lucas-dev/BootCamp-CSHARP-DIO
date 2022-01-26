using System.Collections.Generic;
using CadastroLivros.Interface;

namespace CadastroLivros.Classes
{
    public class BookRepository : IRepository<Book>
    {
        private List<Book> bookList = new List<Book>();

        public void insert(Book entity)
        {
            bookList.Add(entity);
        }

        public void update(int ID, Book entity)
        {
            bookList[ID] = entity;
        }

        public List<Book> toList()
        {
            return this.bookList;
        }

        public int nextID()
        {
            return bookList.Count;
        }

        public Book searchByID(int ID)
        {
            return bookList[ID];
        }

        public void delete(int ID)
        {
            bookList[ID].deleteBook();
        }

        public bool isThereBook()
        { //Método para checar se tem livro no repositório
            return (bookList.Count > 0);
        }

        public int validID(int id)
        {
            if (id < 0 || id > bookList.Count)
            {
                return -1;
            }
            return 0;
        }
    }
}
