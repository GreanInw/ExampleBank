using ExampleBank.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleBank.Web.Commons
{
    public class InternalBaseController : Controller
    {
        public InternalBaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }

        protected IActionResult ReturnResponse(ResultModel model)
            => ModelState.IsValid ? View(model) : BadRequest(model);

        protected IActionResult ReturnResponse<T>(ResultModel<T> model)
            => ModelState.IsValid ? View(model) : BadRequest(model);
    }
}
