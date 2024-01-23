
namespace DemoBank.Models.Models
{
    public class AccountOpeningCreateDto
    {

        public string ProductType { get; set; }

        public string AccountNumber { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreationDate { get; set; }

        public string Branch { get; set; }

        public Guid ClientId { get; set; }
    }
}
