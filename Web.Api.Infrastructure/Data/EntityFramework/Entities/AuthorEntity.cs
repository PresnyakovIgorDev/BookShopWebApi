using System.Collections.Generic;

namespace Web.Api.Infrastructure.Data.EntityFramework.Entities
{
    public class AuthorEntity : BaseEntity
    {
        public string FirstName { get; }
        public string LastName { get; }
        public IEnumerable<BookEntity> BookEntities { get; }
    }


}
