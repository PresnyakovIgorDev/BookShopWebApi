using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.UseCases;
using Web.API.Presenters;
using Xunit;


namespace Web.Api.UnitTests.Presenters
{
    public class GetBookListPresenterTests
    {
        [Fact]
        public void ContainsOkStatusWhenGetBooksListOk()
        {
            var presenter = new GetBookListPresenter();
            presenter.Handle(new GetBookListResponse((IEnumerable<Book>)new Book[] { new Book(1, "TestBook", new Author(1, "first", "last"), "12345") }));
            Assert.Equal((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
        }

        [Fact]
        public void ContainsBooksWhenGetBooksListOk()
        {
            var books = new Book[] { new Book(1, "TestBook", new Author(1, "first", "last"), "12345") };
            var presenter = new GetBookListPresenter();
            presenter.Handle(new GetBookListResponse((IEnumerable<Book>)books));
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);

            Assert.Equal(books.First().Id, data.books.First.id.Value);
            Assert.Equal(books.First().ISBN, data.books.First.isbn.Value);
            Assert.Equal(books.First().Title, data.books.First.title.Value);
            Assert.Equal(books.First().Author.Id, data.books.First.author.id.Value);

        }
    }
}
