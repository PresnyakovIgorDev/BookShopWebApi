using System;
using System.Text;

namespace Web.Api.Infrastructure.Data.EntityFramework.Entities
{
    public class BookEntity : BaseEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public AuthorEntity AuthorEntity { get; set; }
    }


}
