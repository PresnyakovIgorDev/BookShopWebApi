using System;
using System.Text;

namespace Web.Api.Core.Domain.Entities
{
    public class Book
    {

        public int Id { get; }
        public string Title { get; }
        public string ISBN  { get; }
        public Author Author { get; }

        public Book(int id, string title, Author author, string iSBN)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
        }

    }
}
