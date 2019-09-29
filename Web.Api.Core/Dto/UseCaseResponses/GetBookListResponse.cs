using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class GetBookListResponse : UseCaseResponseMessage
    {
        public IEnumerable<Error> Errors { get; }
        public IEnumerable<Book> Books { get; }


        public GetBookListResponse(IEnumerable<Book> books , bool success = true, string message = null) : base(success, message)
        {
            Books = books;
        }

        public GetBookListResponse(IEnumerable<Error> errors,bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

    }
}
