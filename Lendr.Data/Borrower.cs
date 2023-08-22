using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Authentication;

namespace Lendr.API.Data
{
    public class Borrower
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Suffix { get; set; }

        [ForeignKey(nameof(CivilStatusId))]
        public int CivilStatusId { get; set; }
        public CivilStatus CivilStatus { get; set; }
    }
}
