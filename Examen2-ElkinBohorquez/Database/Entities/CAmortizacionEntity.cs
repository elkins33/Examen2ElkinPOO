namespace Examen2_ElkinBohorquez.Database.Entities;

public class CAmortizacionEntity
{

    public int NoCuota { get; set; }
    public DateTime Fecha { get; set; }
    public int Dias { get; set; }
    public int Interes { get; set; }
    public int Abono { get; set; }
    public int CargosISV { get; set; }
    public int CuotaNOISV { get; set; }
    public int ExtraA { get; set; }
    public int CuotaSISV { get; set; }
    public int PSaldo { get; set; } 

}
