namespace Examen2_ElkinBohorquez.Models
{
    public class LoanRequest
    {
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal InterestRate { get; set; }
        public int Term { get; set; }
        public DateTime DisbursementDate { get; set; }
        public DateTime FirstPaymentDate { get; set; }
    }

    
}
