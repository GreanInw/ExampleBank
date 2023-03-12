using ExampleBank.Web.Models.Transactions.Requests;
using ExampleBank.Web.Models.Transactions.Responses;
using ExampleBank.Web.Services.Transactions.Queries;
using MediatR;

namespace ExampleBank.Web.CQRS.Transactions.Queries
{
    public class GetTransactionsByAccountQueryHandler : IRequestHandler<GetTransactionsByAccountRequestModel
        , IEnumerable<GetTransactionsByAccountResponseModel>>
    {
        public GetTransactionsByAccountQueryHandler(ITransactionQueryService transactionQueryService)
        {
            TransactionQueryService = transactionQueryService;
        }

        public ITransactionQueryService TransactionQueryService { get; }

        public async Task<IEnumerable<GetTransactionsByAccountResponseModel>> Handle(
            GetTransactionsByAccountRequestModel request, CancellationToken cancellationToken)
            => await TransactionQueryService.GetByAsync(request);
    }
}
