using System;
using System.Collections.Generic;
using Library.Code;
using Library.Models.Blank;
using Library.Models.ViewModel;
using Library.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
	public class LibraryController : ControllerBase
	{
		private BookCode _bookCode;

		public LibraryController(ILibraryService libraryService)
		{
			_bookCode = new BookCode(libraryService);
		}

		[HttpGet]
		[Route("getbooks")]
		public List<BookViewModel> GetBooks()
		{
			return _bookCode.GetBooks();
		}

		[HttpGet]
		[Route("getbook/{id?}")]
		public BookViewModel GetBooks(Int32 id)
		{
			return _bookCode.GetBook(id);
		}

		[HttpPost]
		[Route("removebook")]
		public void RemoveBook([FromBody]Int32 id)
		{
			_bookCode.RemoveBook(id);
		}

		[HttpPost]
		[Route("removebooks")]
		public void RemoveBooks([FromBody]Int32[] ids)
		{
			_bookCode.RemoveBooks(ids);
		}

		[HttpPost]
		[Route("updatebook")]
		public void UpdateBook([FromBody]BookBlank blank)
		{
			_bookCode.UpdateBook(blank);
		}

		[HttpPost]
		[Route("addbook")]
		public void AddBook([FromBody]BookBlank blank)
		{
			_bookCode.AddBook(blank);
		}
	}
}