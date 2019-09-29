using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.UseCases;
using Xunit;

namespace Web.Api.Core.UnitTests.UseCases
{
    public class GetBookListUseCaseUnitTests
    {
        [Fact]
        public async void CanGetBookList()
        {
            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository
                .Setup(repo => repo.GetAllBooks())
                .Returns(Task.FromResult((IEnumerable<Book>)new Book[] { new Book(1,"TestBook", new Author(1,"first","last"),"12345") }));

            var mockOutputPort = new Mock<IOutputPort<GetBookListResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetBookListResponse>()));

            var useCase = new GetBookListUseCase(mockBookRepository.Object);
            var response = await useCase.Handle(new GetBookListRequest(), mockOutputPort.Object);

            Assert.True(response);
        }
    }
}
