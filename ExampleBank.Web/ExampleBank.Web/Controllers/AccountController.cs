using ExampleBank.Web.Commons;
using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Models.Transactions.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public IActionResult Deposit(string id, string ibam
            , [FromQuery(Name = "s")] bool success = true
            , [FromQuery(Name = "m")] string message = "")
            => View(new ResultModel<DepositAccountRequestModel>
            {
                Success = success,
                Message = message,
                Result = new DepositAccountRequestModel
                {
                    Id = id,
                    IBAM = ibam
                }
            });

        [HttpPost]
        public async Task<IActionResult> Deposit(DepositAccountRequestModel model)
        {
            var result = await Mediator.Send(model);
            return result.Success
                ? RedirectToAction("Index", "Account")
                : RedirectToAction("Deposit", "Account", new
                {
                    id = model.Id,
                    ibam = model.IBAM,
                    s = result.Success,
                    m = result.Message
                });
        }

        [HttpGet]
        public async Task<IActionResult> Transfer(string id, string ibam
            , [FromQuery(Name = "s")] bool success = true
            , [FromQuery(Name = "m")] string message = "")
        {
            var result = await Mediator.Send(new GetTransferInfoRequestModel
            {
                AccountId = id,
                ExcludeIBAM = ibam,
                IBAM = ibam
            });

            return View(new ResultModel<TransferAccountRequestModel>
            {
                Success = success,
                Message = message,
                Result = new TransferAccountRequestModel
                {
                    Id = id,
                    IBAM = ibam,
                    TotalAmount = result.TotalAmount,
                    IBAMItems = result.IBAMItems
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferAccountRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Transfer", "Account", new
                {
                    id = model.Id,
                    ibam = model.IBAM,
                    s = false,
                    m = GetErrorMessages()
                });
            }

            var result = await Mediator.Send(model);
            return result.Success ? RedirectToAction("Index", "Account")
                : RedirectToAction("Transfer", "Account", new
                {
                    id = model.Id,
                    ibam = model.IBAM,
                    s = result.Success,
                    m = result.Message
                });
        }

        [HttpGet]
        public async Task<IActionResult> Transactions(string id, string ibam)
            => View(await Mediator.Send(new GetTransactionsByAccountRequestModel { Id = id, IBAM = ibam }));
    }
}