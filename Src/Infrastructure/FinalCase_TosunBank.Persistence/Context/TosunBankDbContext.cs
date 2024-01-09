using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;

namespace FinalCase_TosunBank.Persistence.Context;

public class TosunBankDbContext : IdentityDbContext<BasePerson, IdentityRole, string>
{
    public TosunBankDbContext(DbContextOptions<TosunBankDbContext> options) : base(options)
    { }
    #region EntitiesDbSet
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Authorised> Authoriseds { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountStatement> AccountStatements { get; set; }
    public DbSet<NewCustomerAccountOpeningRequest> NewCustomerAccountOpeningRequest { get; set; }
    public DbSet<NewBankAccountOpeningRequest> NewBankAccountOpeningRequest { get; set; }
    public DbSet<TransactionType> TransactionTypes { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AccountStatement>()
        .HasOne(c => c.CreatedBy)
        .WithMany()
        .HasForeignKey(x => x.CreatedById);
        base.OnModelCreating(builder);
    }
}
