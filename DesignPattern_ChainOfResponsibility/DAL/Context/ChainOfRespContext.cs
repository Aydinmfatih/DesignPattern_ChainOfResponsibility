using DesignPattern_ChainOfResponsibility.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern_ChainOfResponsibility.DAL.Context
{
    public class ChainOfRespContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;initial catalog=DbChainOfResponsibility;integrated Security=true");
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
//MSI\SQLEXPRESS
