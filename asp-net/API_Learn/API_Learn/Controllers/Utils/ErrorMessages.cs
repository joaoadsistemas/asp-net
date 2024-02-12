using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DSLearn.Controllers.Utils
{
    public static class ErrorMessages
    {
        public static ActionResult<string> ErrorMessage(int id)
        {
            return new BadRequestObjectResult($"Id {id} does not exist");
        }


    }
}
