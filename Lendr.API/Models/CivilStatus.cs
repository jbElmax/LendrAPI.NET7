using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Lendr.API.Models
{
    public class CivilStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Borrower> Borrowers { get; set; }
    }
}