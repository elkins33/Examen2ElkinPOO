namespace Examen2_ElkinBohorquez.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
