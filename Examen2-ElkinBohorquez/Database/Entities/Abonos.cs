using Examen2_ElkinBohorquez.Modelos;

namespace Examen2_ElkinBohorquez.Database.Entities;

public class Abonos
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public string Cliente { get; set; }
    public decimal TasaInteresAnual { get; set; }
    public int Plazo { get; set; }
    public decimal Mensual { get; set; }
    public DateTime InicioPago { get; set; }
}
