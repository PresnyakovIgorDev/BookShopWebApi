using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Core.UseCases;
using Web.API.Presenters;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class BooksController : ControllerBase
    {
        private readonly IGetBookListUseCase _getBookListUseCase;
        private readonly GetBookListPresenter _getBookListPresenter;

        public BooksController(IGetBookListUseCase getBookListUseCase, GetBookListPresenter getBookListPresenter)
        {
            _getBookListUseCase = getBookListUseCase;
            _getBookListPresenter = getBookListPresenter;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _getBookListUseCase.Handle(new GetBookListRequest(), _getBookListPresenter);
            return _getBookListPresenter.ContentResult;
        }
    }
}