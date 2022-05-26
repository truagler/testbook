using Library.Models.DBmodel;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
	public sealed class LibraryDbcontext: DbContext
	{
		public DbSet<BookDb> Book { get; set; }
		
		public LibraryDbcontext(DbContextOptions<LibraryDbcontext> options) 
			:base(options)
		{
			Database.EnsureCreated();
		}
	}
}