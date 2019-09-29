using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Domain.Entities;
using Web.Api.Infrastructure.Data.EntityFramework.Entities;

namespace Web.Api.Infrastructure.Data.EntityFramework.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<BookEntity, Book>().ConstructUsing(book =>  new Book(book.Id, book.Title, book.AuthorEntity == null ? null : new Author(book.AuthorEntity.Id, book.AuthorEntity.FirstName, book.AuthorEntity.LastName), book.ISBN));
        }
    }
}
