using Microsoft.EntityFrameworkCore;

namespace FinalCase_TosunBank.Persistence.Context;

public class TosunBankDbContext : DbContext
{
    public TosunBankDbContext(DbContextOptions options) : base(options)
    { }
    #region EntitiesDbSet
    #endregion
}
