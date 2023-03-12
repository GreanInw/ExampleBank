using ExampleBank.Web.Models.Transactions.Requests;
using ExampleBank.Web.Models.Transactions.Responses;
using ExampleBank.Web.Repositories.Transactions.Queries;
using Microsoft.EntityFrameworkCore;

namespace ExampleBank.Web.Services.Transactions.Queries
{
    public class TransactionQueryService : ITransactionQueryService
    {
        public TransactionQueryService(ITransactionQueryRepository transactionQueryRepository)
        {
            TransactionQueryRepository = transactionQueryRepository;
        }

        public ITransactionQueryRepository TransactionQueryRepository { get; }

        public async Task<IEnumerable<GetTransactionsByAccountResponseModel>> GetByAsync(GetTransactionsByAccountRequestModel model)
            => await TransactionQueryRepository.All.AsNoTracking()
                .Where(w => w.AccountId == Guid.Parse(model.Id) && w.IBAN == model.IBAM)
                .Select(s => new GetTransactionsByAccountResponseModel
                {
                    TransDate = s.TransDate,
                    Amount = s.Amount,
                    IBAN = s.IBAN,
                    Balance = s.Balance,
                    Description = s.Description,
                    Fee = s.Fee,
                    TransactionType = s.TransactionType,
                }).OrderByDescending(o => o.TransDate).ToListAsync();
    }
}