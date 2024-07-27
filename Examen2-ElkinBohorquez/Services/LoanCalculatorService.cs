using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen2_ElkinBohorquez.Models;

namespace Examen2_ElkinBohorquez.Services
{
    public class LoanCalculatorService
    {
        public decimal CalculateLevelPayment(decimal loanAmount, decimal annualInterestRate, int termMonths)
        {
            decimal monthlyInterestRate = annualInterestRate / 12 / 100;
            decimal divisor = (decimal)Math.Pow((double)(1 + monthlyInterestRate), termMonths) - 1;
            decimal numerator = monthlyInterestRate * (decimal)Math.Pow((double)(1 + monthlyInterestRate), termMonths);

            return loanAmount * (numerator / divisor);
        }

        public decimal CalculateMonthlyInterest(decimal principal, decimal annualInterestRate, int daysInMonth)
        {
            decimal dailyInterestRate = annualInterestRate / 360 / 100;
            return principal * dailyInterestRate * daysInMonth;
        }

        public decimal CalculatePrincipal(decimal monthlyPayment, decimal monthlyInterest)
        {
            return monthlyPayment - monthlyInterest;
        }

        public decimal CalculateSVSD(decimal principal)
        {
            decimal svsd = principal * 0.0015m; // 0.15%
            return svsd < 2 ? 2 : svsd;
        }

        public decimal CalculateTotalPayment(decimal monthlyPayment, decimal svsd)
        {
            return monthlyPayment + svsd;
        }

        public decimal CalculatePrincipalBalance(decimal previousPrincipal, decimal principalPayment)
        {
            return previousPrincipal - principalPayment;
        }

        public decimal CalculateLateInterest(decimal overduePrincipal, decimal annualInterestRate, int daysLate)
        {
            decimal lateInterestRate = annualInterestRate * 0.5m / 360 / 100;
            return overduePrincipal * lateInterestRate * daysLate;
        }
    }
}
