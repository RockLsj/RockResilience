using Business.EntityFrameworkCore.UnitOfWorks;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Api.Filters
{
    public class EnsureModelExists : TypeFilterAttribute
    {
        public EnsureModelExists() : base(typeof(EnsureModelExistsFilter)) { }

        public class EnsureModelExistsFilter : IActionFilter
        {
            private IUnitOfWork _unitOfWork;

            private TestService _service = new TestService();

            public EnsureModelExistsFilter(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;

                _service.UnitOfWork = _unitOfWork;
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                var recipeId = (int)context.ActionArguments["id"];
                if (!_service.IsExist(recipeId))
                {
                    context.Result = new NotFoundResult();
                }
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
            }
        }
    }
}
