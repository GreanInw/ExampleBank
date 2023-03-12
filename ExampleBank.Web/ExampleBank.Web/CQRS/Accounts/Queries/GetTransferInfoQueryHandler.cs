using ExampleBank.Web.Models.Accounts.Requests;
using ExampleBank.Web.Models.Accounts.Responses;
using ExampleBank.Web.Services.Accounts.Queries;
using MediatR;

namespace ExampleBank.Web.CQRS.Accounts.Queries
{
    public class GetTransferInfoQueryHandler : IRequestHandler<GetTransferInfoRequestModel, GetTransferInfoResponseModel>
    {
        public GetTransferInfoQueryHandler(IAccountInfoQueryService accountInfoQueryService)
        {
            AccountInfoQueryService = accountInfoQueryService;
        }

        public IAccountInfoQueryService AccountInfoQueryService { get; }

        public async Task<GetTransferInfoResponseModel> Handle(GetTransferInfoRequestModel request, CancellationToken cancellationToken)
            => await AccountInfoQueryService.GetTransferInfoAsync(request);
    }
}
