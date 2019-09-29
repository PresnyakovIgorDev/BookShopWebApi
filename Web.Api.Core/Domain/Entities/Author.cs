using System.Collections.Generic;

namespace Web.Api.Core.Domain.Entities
{
    public class Author
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public IEnumerable<Book> Books { get; }

        public Author(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
