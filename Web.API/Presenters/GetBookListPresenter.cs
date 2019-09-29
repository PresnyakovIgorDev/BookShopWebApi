using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.API.Serialization;

namespace Web.API.Presenters
{
    public sealed class GetBookListPresenter : IOutputPort<GetBookListResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetBookListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetBookListResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
