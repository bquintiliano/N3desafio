using N3desafio.Communication.Requests;
using N3desafio.Communication.Responses;
using System.Collections.Generic;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace N3desafio.Services
{
    public class BookServices
    {
        private string pathDB = $"{Environment.CurrentDirectory}\\DB\\db.json";
        public List<ResponseCreateBook> GetBooks()
        {
            List<ResponseCreateBook> books = ReadDB();
            return books;
        }

        public ResponseCreateBook PostBook(RequestCreateBook book)
        {
            List<ResponseCreateBook> books = ReadDB();
            int id = 1;

            if (books.Count > 0)
                id = books.LastOrDefault().Id + 1;

            ResponseCreateBook newBook = new ResponseCreateBook()
            {
                Id = id,
                Author = book.Author,
                Genre = book.Genre,
                Price = book.Price,
                Quantity = book.Quantity,
                Title = book.Title,
            };
            books.Add(newBook);

            WriteDB(books);

            return newBook;
        }

        public ResponseCreateBook PutBook(RequestCreateBook book, int id)
        {
            List<ResponseCreateBook> books = ReadDB();

            var findBook = SearchBook(books, id);

            if (findBook == null)
                return null;

            findBook.Author = book.Author;
            findBook.Genre = book.Genre;
            findBook.Price = book.Price;
            findBook.Quantity = book.Quantity;
            findBook.Title = book.Title;

            WriteDB(books);

            return findBook;
        }

        public ResponseCreateBook DeleteBook(int id)
        {
            List<ResponseCreateBook> books = ReadDB();

            var findBook = SearchBook(books, id);

            if (findBook == null)
                return null;

            books.Remove(findBook);

            WriteDB(books);

            return findBook;
        }

        private List<ResponseCreateBook> ReadDB()
        {
            List<ResponseCreateBook> books = new List<ResponseCreateBook>();

            var readDB = File.ReadAllBytes(pathDB);

            if (readDB.Length > 0)
                books = JsonSerializer.Deserialize<List<ResponseCreateBook>>(readDB);

            return books;
        }

        private void WriteDB(List<ResponseCreateBook> books)
        {
            var convertBook = JsonSerializer.SerializeToUtf8Bytes(books);

            File.WriteAllBytes(pathDB, convertBook);
        }

        private ResponseCreateBook SearchBook(List<ResponseCreateBook> books, int id)
        {
            if (books.Count == 0)
                return null;

            var findBook = books.FirstOrDefault(b => b.Id == id);

            if (findBook == null)
                return null;

            return findBook;
        }
    }
}
