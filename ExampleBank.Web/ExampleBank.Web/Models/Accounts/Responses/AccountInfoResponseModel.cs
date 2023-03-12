using ExampleBank.Web.Enums;

namespace ExampleBank.Web.Models.Accounts.Responses
{
    public class AccountInfoResponseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<BankAccountInfo> BankAccounts { get; set; }
        public int TotalBankAccounts => BankAccounts.Count();

        public class BankAccountInfo
        {
            public string IBAM { get; set; }
            public string AccountId { get; set; }
            public BankAccountType Type { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
