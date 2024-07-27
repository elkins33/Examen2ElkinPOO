using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen2_ElkinBohorquez.Modelos;
using System;
using Examen2_ElkinBohorquez.Database;
using Examen2_ElkinBohorquez.Database.Entities;

[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly DBPrestamoContext _context;

    public LoansController(DBPrestamoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PrestamoEntity>>> GetLoans()
    {
        return await _context.Prestamo.Include(l => l.Client).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PrestamoEntity>> GetLoan(int id)
    {
        var loan = await _context.Prestamo.Include(l => l.Client).FirstOrDefaultAsync(l => l.Id == id);

        if (loan == null)
        {
            return NotFound();
        }

        return loan;
    }

    [HttpPost]
    public async Task<ActionResult<PrestamoEntity>> PostLoan(PrestamoEntity prestamo)
    {
        prestamo.MonthlyPayment = CalculateMonthlyPayment(prestamo., prestamo., prestamo.);
        _context.Prestamo.Add(prestamo);
        await _context.SaveChangesAsync();

        // Generate amortization schedule
        GenerateAmortizationSchedule(prestamo);

        return CreatedAtAction(nameof(GetLoan), new { id = prestamo.Id }, prestamo);
    }

    private decimal CalculateMonthlyPayment(decimal principal, decimal annualRate, int termInYears)
    {
        var monthlyRate = annualRate / 12 / 100;
        var numberOfPayments = termInYears * 12;
        var monthlyPayment = principal * (monthlyRate * (decimal)Math.Pow(1 + (double)monthlyRate, numberOfPayments)) / (decimal)(Math.Pow(1 + (double)monthlyRate, numberOfPayments) - 1);
        return monthlyPayment;
    }

    private void GenerateAmortizationSchedule(PrestamoEntity loan)
    {
        var balance = loan.;
        var monthlyRate = loan. / 12 / 100;
        var monthlyPayment = loan.;

        for (int i = 1; i <= loan. * 12; i++)
        {
            var interest = balance * monthlyRate;
            var principal = monthlyPayment - interest;
            balance -= principal;

            var schedule = new //falta
            {
              
            };

            _context..Add(schedule);
        }

        _context.SaveChanges();
    }
}
