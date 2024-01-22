using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoBank.DAL.Database.DBModels
{
    public class Client
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClientId { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string DocumentType { get; set; }

        public string IdentityDocument { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }
    }
}
