using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Context;
using Project.WebAPI.DTOs;
using Project.WebAPI.Models;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CodeController : CustomBaseController
    {
        private readonly CodeDbContext _context;
        private readonly IMapper _mapper;

        public CodeController(CodeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpPost]
        public async Task<IActionResult> GeneratCodes(CreateCodeDto createCodeDto)
        {
            
            // stored proc'dan geri değer döndürmesini istemediğiniz için ExecuteSqlInterpolated kullandık. 
            _context.Database.ExecuteSqlInterpolated($"EXEC dbo.sp_Generate_Codes @length = {createCodeDto.Length}, @characters = {createCodeDto.CharacterSet}, @count = {createCodeDto.Count}");

            // return Ok(CustomResponseDto<Code>.Success(200));
            // her seferinde Ok- badrequest gibi dondurmek yerine basecontrollerden tek bir seferden çekiyoruz
            // 201 Created

            return CreateActionResult(CustomResponseDto<NoContentResponseDto>.Success(201));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Code> codes = await _context.Codes.ToListAsync();

            List<CodeDto> codesDto = _mapper.Map<List<CodeDto>>(codes);

            return CreateActionResult(CustomResponseDto<List<CodeDto>>.Success(200,codesDto));
        }

    }
}
