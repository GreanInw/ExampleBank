using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Models.Accounts.Responses;
using ExampleBank.Web.Services.Accounts.Commands;
using MediatR;

namespace ExampleBank.Web.CQRS.Accounts.Commands
{
    public class DepositAccountCommandHandler : IRequestHandler<DepositAccountRequestModel, ResultModel<DepositAccountResponseModel>>
    {
        public DepositAccountCommandHandler(IAccountInfoCommandService accountInfoCommandService)
        {
            AccountInfoCommandService = accountInfoCommandService;
        }

        public IAccountInfoCommandService AccountInfoCommandService { get; }

        public async Task<ResultModel<DepositAccountResponseModel>> Handle(DepositAccountRequestModel request, CancellationToken cancellationToken)
            => await AccountInfoCommandService.DepositAsync(request);
    }
}