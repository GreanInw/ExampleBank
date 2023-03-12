using ExampleBank.Web.Data.Bases;
using ExampleBank.Web.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleBank.Web.Data.Tables
{
    [Table(nameof(Transaction))]
    public class Transaction : IIBANEntity
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public TransactionType TransactionType { get; set; }
        public Guid AccountId { get; set; }
        public string IBAN { get; set; }
        public DateTime TransDate { get; set; }

        [Column(TypeName = "decimal(20,4)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(25,8)")]
        public decimal Fee { get; set; }
        [Column(TypeName = "decimal(25,8)")]
        public decimal Balance { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
    }
}