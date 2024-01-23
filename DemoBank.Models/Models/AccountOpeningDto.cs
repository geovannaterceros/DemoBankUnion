
namespace DemoBank.Models.Models
{
    public class AccountOpeningDto
    {
        public Guid AccountId { get; set; } = Guid.NewGuid();

        public string ProductType { get; set; }

        public string AccountNumber { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreationDate { get; set; }

        public string Branch { get; set; }

        public Guid ClientId { get; set; }
    }
}
