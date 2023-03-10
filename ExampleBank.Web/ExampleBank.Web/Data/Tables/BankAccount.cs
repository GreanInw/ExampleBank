using ExampleBank.Web.Data.Auditables;
using ExampleBank.Web.Data.Bases;
using ExampleBank.Web.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleBank.Web.Data.Tables
{
    public class BankAccount : IAuditableEntity, IIBANEntity
    {
        public string IBAN { get; set; }
        public Guid AccountId { get; set; }

        [Column(TypeName = "decimal(20,4)")]
        public decimal Amount { get; set; }
        public BankAccountType BankAccountType { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
