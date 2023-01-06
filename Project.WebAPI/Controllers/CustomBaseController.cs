using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.WebAPI.DTOs;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        // her seferinde OK- BadRequest gibi donmek yerine tek bir yerden döndürüyoruz
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if(response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode= response.StatusCode,
                };

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };

        }
    }
}
