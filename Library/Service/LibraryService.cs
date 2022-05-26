using System;
using System.Collections.Generic;
using Library.Models.Domain;
using Library.Repository.Interface;
using Library.Service.Interface;
using Library.Tools;

namespace Library.Service
{
	public class LibraryService: ILibraryService
	{
		private ILibraryRepository _libraryRepository;

		private Converter.Converter _converter = new Converter.Converter();

		public LibraryService(ILibraryRepository libraryRepository)
		{
			_libraryRepository = libraryRepository;
		}

		public List<Book> GetBooks()
		{
			return _converter.ToDomains(_libraryRepository.GetBooks());
		}

		public Book GetBook(Int32 id)
		{
			return _converter.ToDomain(_libraryRepository.GetBook(id));
		}

		public void RemoveBook(Int32 id)
		{
			_libraryRepository.RemoveBook(id);
		}

		public void RemoveBooks(Int32[] ids)
		{
			_libraryRepository.RemoveBooks(ids);
		}

		public void UpdateBook(Book book)
		{
			_libraryRepository.UpdateBook(_converter.ToDb(book));
		}

		public void AddBook(Book book)
		{
			book.Id = ID.NewID();
			book.IsRemoved = false;
			_libraryRepository.AddBook(_converter.ToDb(book));
		}
	}
}