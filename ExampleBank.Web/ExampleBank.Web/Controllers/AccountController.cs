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
        public IActionResult Upsert() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountRequestModel model)
            => ReturnResponse(await Mediator.Send(model));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAccountRequestModel model)
            => ReturnResponse(await Mediator.Send(model));
    }
}