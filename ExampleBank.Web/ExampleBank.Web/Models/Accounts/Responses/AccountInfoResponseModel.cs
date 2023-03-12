using ExampleBank.Web.Enums;

namespace ExampleBank.Web.Models.Accounts.Responses
{
    public class AccountInfoResponseModel
    {
        public AccountInfoResponseModel()
        {
            BankAccounts = new List<BankAccountInfo>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<BankAccountInfo> BankAccounts { get; set; }
        public int TotalBankAccounts => BankAccounts.Count();
        public string TotalAmounts
        {
            get
            {
                var savingAmt = BankAccounts.Where(w => w.Type == BankAccountType.Saving).Sum(s => s.Amount);
                var currentAmt = BankAccounts.Where(w => w.Type == BankAccountType.CurrentAccount).Sum(s => s.Amount);
                return $"Saving amount : {savingAmt:n4}, Current account amount : {currentAmt:n4}";
            }
        }

        public class BankAccountInfo
        {
            public string IBAM { get; set; }
            public string AccountId { get; set; }
            public BankAccountType Type { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
