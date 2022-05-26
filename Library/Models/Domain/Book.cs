using System;
using Library.Models.Enum;

namespace Library.Models.Domain
{
	public class Book
	{
		public Int32 Id { get; set; }
		public String Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public Genre Genre { get; set; }
		public String Author { get; set; }
		public Boolean IsRemoved { get; set; }

		public Book() { }

		public Book(Int32 id, String name, DateTime createdDate, Genre genre, String author, Boolean isRemoved)
		{
			Id = id;
			Name = name;
			CreatedDate = createdDate;
			Genre = genre;
			Author = author;
			IsRemoved = isRemoved;
		}
	}
}