using Microsoft.AspNetCore.Mvc;

namespace Web.API.Presenters
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
