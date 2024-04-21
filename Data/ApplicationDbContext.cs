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

}
