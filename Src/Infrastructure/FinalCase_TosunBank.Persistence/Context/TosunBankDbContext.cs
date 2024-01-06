﻿using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalCase_TosunBank.Persistence.Context;

public class TosunBankDbContext : IdentityDbContext<BasePerson>
{
    public TosunBankDbContext(DbContextOptions<TosunBankDbContext> options) : base(options)
    { }
    #region EntitiesDbSet
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Authorised> Authoriseds { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountStatement> AccountStatements { get; set; }
    #endregion
}
