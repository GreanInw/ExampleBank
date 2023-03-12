using ExampleBank.Web.Models;
using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Services.Accounts.Commands;
using MediatR;

namespace ExampleBank.Web.CQRS.Accounts.Commands
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountRequestModel, ResultModel>
    {
        public UpdateAccountCommandHandler(IAccountInfoCommandService accountInfoCommandService)
        {
            AccountInfoCommandService = accountInfoCommandService;
        }

        public IAccountInfoCommandService AccountInfoCommandService { get; }

        public async Task<ResultModel> Handle(UpdateAccountRequestModel request, CancellationToken cancellationToken)
            => await AccountInfoCommandService.UpdateAsync(request);
    }
}