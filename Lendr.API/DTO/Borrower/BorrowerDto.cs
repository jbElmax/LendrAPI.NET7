namespace Lendr.API.DTO.Borrower
{
    public class BorrowerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Suffix { get; set; }

        public int CivilStatusId { get; set; }
    }
}
