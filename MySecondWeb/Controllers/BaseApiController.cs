using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MySecondWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected async Task<IActionResult> HandleException(Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            if (ex is PrimaryKeyViolationException || ex is ForeignKeyViolationException)
            {
                return BadRequest(ex.Message);
            }
            else
                switch (ex)
                {
                    case ForbiddenException _:
                        return StatusCode(403);
                    case UnAuthorizedException _:
                        return StatusCode(401);
                    case RecordNotFoundException _:
                        return BadRequest(ex.Message);
                    case SameNameException _:
                        return BadRequest(ex.Message);
                    case InvalidProcessException _:
                        return BadRequest(ex.Message);
                    case InvalidDataException _:
                        return BadRequest(ex.Message);
                    case UserSecurityException _:
                        return BadRequest(ex.Message);
                    case NullObjectException _:
                        return BadRequest(ex.Message);
                    case BlobExteption _:
                        return BadRequest($"blobException-{ex.Message}");
                    case MySqlException _:
                        return BadRequest(ex.Message);
                    case OperationFailedException _:
                        return BadRequest(ex.Message);
                    case DataInconsistencyClientException _:
                        return BadRequest(ex.Message);
                    //case EatException _:
                    //    await LogException(ex);
                    //    return Ok();
                    default:
                       // await LogException(ex);
                        return StatusCode(500, ex.Message);
                }
        }
    }
}