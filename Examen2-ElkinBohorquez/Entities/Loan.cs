using Examen2_ElkinBohorquez.Models;

namespace Examen2_ElkinBohorquez.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int ClientId { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal InterestRate { get; set; }
        public int Term { get; set; }
        public DateTime DisbursementDate { get; set; }
        public DateTime FirstPaymentDate { get; set; }
        public Client Client { get; set; }

        public ICollection<AmortizationDetail> Amortizations { get; set; }
    }
}
