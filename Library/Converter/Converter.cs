using System.Collections.Generic;
using System.Linq;
using Library.Models.Blank;
using Library.Models.DBmodel;
using Library.Models.Domain;
using Library.Models.ViewModel;

namespace Library.Converter
{
	public class Converter
	{
		public Book ToDomain(BookDb bookDb)
		{
			return new Book(bookDb.Id, bookDb.Name, bookDb.CreatedDate, bookDb.Genre, bookDb.Author, bookDb.IsRemoved);
		}
		
		public Book ToDomain(BookBlank book)
		{
			return new Book(book.Id, book.Name, book.CreatedDate, book.Genre, book.Author, false);
		}
		
		public List<Book> ToDomains(List<BookDb> bookDbs)
		{
			return bookDbs.Select(ToDomain).ToList();
		}
		
		public BookDb ToDb(Book book)
		{
			return new BookDb(book.Id, book.Name, book.CreatedDate, book.Genre, book.Author, book.IsRemoved);
		}
		
		public List<BookDb> ToDbs(List<Book> bookDbs)
		{
			return bookDbs.Select(ToDb).ToList();
		}
		
		public BookViewModel ToView(Book book)
		{
			return new BookViewModel(book.Id, book.Name, book.CreatedDate, book.Genre, book.Author);
		}
		
		public List<BookViewModel> ToViews(List<Book> book)
		{
			return book.Select(ToView).ToList();
		}
	}
}