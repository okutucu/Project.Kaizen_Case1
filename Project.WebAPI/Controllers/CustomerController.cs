using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Context;
using Project.WebAPI.DTOs;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CustomBaseController
    {
        private readonly CodeDbContext _context;

        public CustomerController(CodeDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> isValidCode(string code) 
        { 
            bool isValid =  _context.Codes.Any( c => c.Name == code);

            if (isValid)
            {
                return Ok("Geçerli Ürün Kodu");
            }

            return CreateActionResult(CustomResponseDto<NoContentResponseDto>.Fail(404,"Geçersiz Kod"));
        }
    }
}
