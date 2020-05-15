using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminCategoryService.Extensions
{
    interface IExceptionFilter : IFilterMetadata
    {
        void OnException(ExceptionContext context);
    }
}
