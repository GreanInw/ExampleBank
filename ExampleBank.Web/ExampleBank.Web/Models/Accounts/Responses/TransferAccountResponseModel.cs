namespace ExampleBank.Web.Models.Accounts.Responses
{
    public class TransferAccountResponseModel
    {
        public string Id { get; set; }
        public string FromIBAM { get; set; }
        public string ToIBAM { get; set; }
        public string ToAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}