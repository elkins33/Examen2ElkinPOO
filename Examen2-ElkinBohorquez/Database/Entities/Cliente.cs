namespace Examen2_ElkinBohorquez.Database.Entities
{
    public class PrestamoEntity
    {
        public string Nombre { get; set; }
        public int NumeroIdenti { get; set; }
        public int MontoPresta { get; set; }
        public int RaComision { get; set; }
        public int RaInteres { get; set; }
        public int Termino { get; set; }
        public DateTime DesembolsoFecha { get; set; }
        public DateTime PrimerPago { get; set; }

    }
}
