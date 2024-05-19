using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace movieappauth.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {}  
    public DbSet<movieappauth.Models.Contacto> DataContacto {get;set;}
    public DbSet<movieappauth.Models.Producto> DataProducto {get;set;}
    public DbSet<movieappauth.Models.Proforma> DataItemCarrito {get;set;}
    public DbSet<movieappauth.Models.Pago> DataPago {get;set;}
    public DbSet<movieappauth.Models.Pedido> DataPedido {get;set;}
    public DbSet<movieappauth.Models.DetallePedido> DataDetallePedido {get;set;}

}