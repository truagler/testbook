using System;
using System.Collections.Generic;
using Library.Models.Domain;

namespace Library.Service.Interface
{
	public interface ILibraryService
	{
		List<Book> GetBooks();
		Book GetBook(Int32 id);
		void RemoveBook(Int32 id);
		void RemoveBooks(Int32[] ids);
		void UpdateBook(Book book);
		void AddBook(Book book);
	}
}