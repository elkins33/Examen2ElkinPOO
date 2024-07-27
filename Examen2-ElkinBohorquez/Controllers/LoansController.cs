using Microsoft.AspNetCore.Mvc;
using Examen2_ElkinBohorquez.Services;
using Examen2_ElkinBohorquez.Models;
using Examen2_ElkinBohorquez.Entities;
using System.Collections.Generic;
using System;

namespace Examen2_ElkinBohorquez.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly LoanCalculatorService _loanCalculatorService;

      
        public LoansController(LoanCalculatorService loanCalculatorService)
        {
            _loanCalculatorService = loanCalculatorService;
        }

        [HttpPost]
        public IActionResult CreateLoan([FromBody] LoanRequest loanRequest)
        {
            
            if (loanRequest == null || loanRequest.LoanAmount <= 0 || loanRequest.Term <= 0)
            {
                return BadRequest("Esa solicitu de prestamo es invalida!");
            }

           
            decimal loanAmount = loanRequest.LoanAmount + (loanRequest.LoanAmount * (loanRequest.CommissionRate / 100));
            decimal monthlyPayment = _loanCalculatorService.CalculateLevelPayment(loanAmount, loanRequest.InterestRate, loanRequest.Term);

            
            var amortizationPlan = new List<AmortizationDetail>();
            decimal principalBalance = loanAmount;
            DateTime paymentDate = loanRequest.FirstPaymentDate;

            for (int month = 1; month <= loanRequest.Term; month++)
            {
                int daysInMonth = DateTime.DaysInMonth(paymentDate.Year, paymentDate.Month);
                decimal monthlyInterest = _loanCalculatorService.CalculateMonthlyInterest(principalBalance, loanRequest.InterestRate, daysInMonth);
                decimal principalPayment = _loanCalculatorService.CalculatePrincipal(monthlyPayment, monthlyInterest);
                decimal svsd = _loanCalculatorService.CalculateSVSD(principalBalance);
                decimal totalPayment = _loanCalculatorService.CalculateTotalPayment(monthlyPayment, svsd);

                amortizationPlan.Add(new AmortizationDetail
                {
                    InstallmentNumber = month,
                    //PaymentDate = paymentDate.ToString("dd-MM-yyyy"), CORREGIR
                    Days = daysInMonth,
                    Interest = monthlyInterest,
                    Principal = principalPayment,
                    LevelPaymentWithoutSVSD = monthlyPayment,
                    LevelPaymentWithSVSD = totalPayment,
                    PrincipalBalance = _loanCalculatorService.CalculatePrincipalBalance(principalBalance, principalPayment)
                });

                principalBalance -= principalPayment;
                paymentDate = paymentDate.AddMonths(1);
            }

            

            return Ok(new
            {
                message = "El paln de prestamo y amortizacion fue creado exitosamente",
                amortizationPlan
            });
        }

        [HttpGet("{clientId}")]
        public IActionResult GetLoanPlan(int clientId)
        {
            

            var amortizationPlan = new List<AmortizationDetail>
            {
                new AmortizationDetail
                {
                    InstallmentNumber = 1,
                    //PaymentDate = "2024-27-07", CORREGIR
                    Days = 31,
                    Interest = 100,
                    Principal = 400,
                    LevelPaymentWithoutSVSD = 500,
                    LevelPaymentWithSVSD = 510,
                    PrincipalBalance = 9600
                }
            };

            return Ok(new
            {
                clientId = clientId,
                name = "David Funez", 
                identityNumber = "337712345", 
                loanAmount = 10000, 
                amortizationPlan
            });
        }
    }
}