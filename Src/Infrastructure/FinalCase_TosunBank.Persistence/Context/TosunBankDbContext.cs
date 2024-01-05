using FinalCase_TosunBank.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalCase_TosunBank.Persistence.Context;

public class TosunBankDbContext : IdentityDbContext<Person>
{
    public TosunBankDbContext(DbContextOptions<TosunBankDbContext> options) : base(options)
    { }
    #region EntitiesDbSet
    public DbSet<Person> Persons { get; set; }
    #endregion
}
