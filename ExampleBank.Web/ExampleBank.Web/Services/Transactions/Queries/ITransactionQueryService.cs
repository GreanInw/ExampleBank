using ExampleBank.Web.Models.Transactions.Requests;
using ExampleBank.Web.Models.Transactions.Responses;

namespace ExampleBank.Web.Services.Transactions.Queries
{
    public interface ITransactionQueryService
    {
        Task<IEnumerable<GetTransactionsByAccountResponseModel>> GetByAsync(GetTransactionsByAccountRequestModel model);
    }
}
