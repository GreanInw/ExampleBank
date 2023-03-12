using ExampleBank.Web.Enums;

namespace ExampleBank.Web.Models.Transactions.Responses
{
    public class GetTransactionsByAccountResponseModel
    {
        public DateTime TransDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public string IBAN { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public decimal Balance { get; set; }
        public string Description { get; set; }
    }
}
