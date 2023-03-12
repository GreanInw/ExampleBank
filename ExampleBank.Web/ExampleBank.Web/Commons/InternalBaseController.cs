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

        protected IActionResult RedirectToError() => RedirectToAction("Error", "Home");

        protected string GetErrorMessages()
            => ModelState.IsValid ? string.Empty 
                : string.Join("<br />", ModelState.Values.SelectMany(s => s.Errors).Select(s => s.ErrorMessage));
    }
}
