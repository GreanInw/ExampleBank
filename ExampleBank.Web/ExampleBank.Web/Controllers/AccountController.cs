using ExampleBank.Web.Commons;
using ExampleBank.Web.Models.Accounts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleBank.Web.Controllers
{
    public class AccountController : InternalBaseController
    {
        public AccountController(IMediator mediator) : base(mediator)
        { }

        [HttpGet]
        public async Task<IActionResult> Index(GetAccountRequestModel model)
            => ReturnResponse(await Mediator.Send(model));

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await Mediator.Send(model);
            return result.Success ? RedirectToAction("Index", "Account") : RedirectToError();
        }
    }
}