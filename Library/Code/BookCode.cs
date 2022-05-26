using System;
using System.Collections.Generic;
using Library.Models.Blank;
using Library.Models.ViewModel;
using Library.Service.Interface;

namespace Library.Code
{
	public class BookCode
	{
		private ILibraryService _libraryService;
		private Converter.Converter _converter = new Converter.Converter();

		public BookCode(ILibraryService libraryService)
		{
			_libraryService = libraryService;
		}

		public List<BookViewModel> GetBooks()
		{
			return _converter.ToViews(_libraryService.GetBooks());
		}

		public BookViewModel GetBook(Int32 id)
		{
			return _converter.ToView(_libraryService.GetBook(id));
		}

		public void RemoveBook(Int32 id)
		{
			_libraryService.RemoveBook(id);
		}

		public void RemoveBooks(Int32[] ids)
		{
			_libraryService.RemoveBooks(ids);
		}

		public void UpdateBook(BookBlank book)
		{
			_libraryService.UpdateBook(_converter.ToDomain(book));
		}

		public void AddBook(BookBlank book)
		{
			_libraryService.AddBook(_converter.ToDomain(book));
		}
	}
}