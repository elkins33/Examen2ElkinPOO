using Microsoft.EntityFrameworkCore;
using Examen2_ElkinBohorquez.Modelos;

using Microsoft.AspNetCore.Authentication;
using Examen2_ElkinBohorquez.Database.Entities;

namespace Examen2_ElkinBohorquez.Database;

public class DBPrestamoContext 
{
    private readonly IAuthenticationService _authService;

    public DBPrestamoContext(DBPrestamoContext options,
        IAuthenticationService authService
        ) : base(options) {

        this._authService = authService;

        //spublic DbSet<Abonos> Clients { get; set; }
        public DbSet<CAmortizacionEntity> Amortizacion { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

}

