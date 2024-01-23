
namespace DemoBank.Models.Models
{
    public class ClientCreateDto
    {

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string DocumentType { get; set; }

        public string IdentityDocument { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }
    }
}
