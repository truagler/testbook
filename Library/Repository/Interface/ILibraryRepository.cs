using System;
using System.Collections.Generic;
using Library.Models.DBmodel;

namespace Library.Repository.Interface
{
	public interface ILibraryRepository
	{
		List<BookDb> GetBooks();
		BookDb GetBook(Int32 id);
		void RemoveBook(Int32 id);
		void RemoveBooks(Int32[] ids);
		void UpdateBook(BookDb newBook);
		void AddBook(BookDb newBook);
	}
}