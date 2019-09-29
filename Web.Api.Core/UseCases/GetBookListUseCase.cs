using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Core.UseCases
{
    public class GetBookListUseCase : IGetBookListUseCase
    {
        private readonly IBookRepository _bookRepository;

        public GetBookListUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(GetBookListRequest message, IOutputPort<GetBookListResponse> outputPort)
        {
            var result = await _bookRepository.GetAllBooks();
            outputPort.Handle(new GetBookListResponse(result));
            return true;
        }
    }
}
