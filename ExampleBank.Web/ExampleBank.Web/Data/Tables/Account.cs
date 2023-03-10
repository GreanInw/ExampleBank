using ExampleBank.Web.Data.Auditables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleBank.Web.Data.Tables
{
    [Table(nameof(Account))]
    public class Account : IAuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BankAccount> BackAccounts { get; set; }
    }
}