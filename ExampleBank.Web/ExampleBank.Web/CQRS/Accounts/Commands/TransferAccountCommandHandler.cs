using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Models.Accounts.Responses;
using ExampleBank.Web.Services.Accounts.Commands;
using MediatR;

namespace ExampleBank.Web.CQRS.Accounts.Commands
{
    public class TransferAccountCommandHandler : IRequestHandler<TransferAccountRequestModel, ResultModel<TransferAccountResponseModel>>
    {
        public TransferAccountCommandHandler(IAccountInfoCommandService accountInfoCommandService)
        {
            AccountInfoCommandService = accountInfoCommandService;
        }

        public IAccountInfoCommandService AccountInfoCommandService { get; }

        public async Task<ResultModel<TransferAccountResponseModel>> Handle(TransferAccountRequestModel request, CancellationToken cancellationToken)
            => await AccountInfoCommandService.TransferAsync(request);
    }
}
