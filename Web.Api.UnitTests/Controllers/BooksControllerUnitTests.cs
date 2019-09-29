using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.UseCases;
using Web.API.Controllers;
using Web.API.Presenters;
using Xunit;

namespace Web.Api.UnitTests.Controllers
{
    public class BooksControllerUnitTests
    {
        [Fact]
        public async void GetBooksListOk()
        {
            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository
                .Setup(repo => repo.GetAllBooks())
                .Returns(Task.FromResult((IEnumerable<Book>)new Book[] { new Book(1, "TestBook", new Author(1, "first", "last"), "12345") }));

            var outputPort = new GetBookListPresenter();
            var useCase = new GetBookListUseCase(mockBookRepository.Object);

            var controller = new BooksController(useCase, outputPort);

            var result = await controller.Get();

            var statusCode = ((ContentResult)result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.OK);
        }
    }
}
