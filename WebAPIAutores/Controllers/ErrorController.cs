using Microsoft.AspNetCore.Mvc;
using WebAPIAutores.Errors;

namespace WebAPIAutores.Controllers
{
    [Route("errors")]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new CodeErrorResponse(code));
        }
    }
}
