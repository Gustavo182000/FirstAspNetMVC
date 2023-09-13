using FirstAspNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAspNetMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<EmprestimosModel> Emprestimos { get; set;}
    }
}
