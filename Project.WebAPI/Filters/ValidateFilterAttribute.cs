using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project.WebAPI.DTOs;

namespace Project.WebAPI.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        // Fluent validator kendi responsu döndüğü için kendi responsumuza çevireceğiz

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(!context.ModelState.IsValid)
            {
                List<string> errors = context.ModelState.Values.SelectMany(x=> x.Errors).Select(x => x.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentResponseDto>.Fail(400,errors));


            }
        }
    }
}
