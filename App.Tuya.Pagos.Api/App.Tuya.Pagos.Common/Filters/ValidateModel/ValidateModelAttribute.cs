using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Tuya.Pagos.Common.Filters.ValidateModel
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }
    }
}
