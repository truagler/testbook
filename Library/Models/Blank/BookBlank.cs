using System;
using Library.Models.Enum;

namespace Library.Models.Blank
{
	public class BookBlank
	{
		public Int32 Id { get; set; }
		public String Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public Genre Genre { get; set; }
		public String Author { get; set; }

		public BookBlank() { }

		public BookBlank(Int32 id, String name, DateTime createdDate, Genre genre, String author)
		{
			Id = id;
			Name = name;
			CreatedDate = createdDate;
			Genre = genre;
			Author = author;
		}
	}
}