using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Models.DBmodel;
using Library.Repository.Interface;

namespace Library.Repository
{
	public class LibraryRepository: ILibraryRepository
	{
		private LibraryDbcontext _db;

		public LibraryRepository(LibraryDbcontext db)
		{
			_db = db;
		}
		
		public List<BookDb> GetBooks()
		{
			List<BookDb> books = new List<BookDb>();
			
			if (_db.Book != null)
			{
				books =  _db.Book.Where(book => book.IsRemoved == false).ToList();
			}

			return books;
		}
		
		public BookDb GetBook(Int32 id)
		{
			BookDb book = new BookDb();
			
			if (_db.Book != null)
			{
				book =  _db.Book.FirstOrDefault(book => book.Id == id);
			}

			return book;
		}
		
		public void RemoveBook(Int32 id)
		{
			BookDb book = _db.Book.FirstOrDefault(book => book.Id == id);
			if (book != null)
			{
				book.IsRemoved = true;
				_db.SaveChanges();
			}
		}
		
		public void RemoveBooks(Int32[] ids)
		{
			foreach (Int32 id in ids)
			{
				BookDb book = _db.Book.FirstOrDefault(book => book.Id == id);
				if (book != null)
				{
					book.IsRemoved = true;
					_db.SaveChanges();
				}
			}
		}
		
		public void UpdateBook(BookDb newBook)
		{
			BookDb book = _db.Book.FirstOrDefault(book => book.Id == newBook.Id);
			if (book != null)
			{
				book.Name = newBook.Name;
				book.Author = newBook.Author;
				book.Genre = newBook.Genre;
				book.CreatedDate = newBook.CreatedDate;
				_db.SaveChanges();
			}
		}
		
		public void AddBook(BookDb newBook)
		{
			_db.Book.Add(newBook);
			_db.SaveChanges();
		}
	}
}