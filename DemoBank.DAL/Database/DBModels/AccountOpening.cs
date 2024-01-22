using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoBank.DAL.Database.DBModels
{
    public class AccountOpening
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AccountId { get; set; } = Guid.NewGuid();

        public string ProductType { get; set; }

        public string AccountNumber { get; set; }

        public decimal Currency { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreationDate { get; set; }

        public string Branch { get; set; }

        public Guid ClientId { get; set; }
    }
}
