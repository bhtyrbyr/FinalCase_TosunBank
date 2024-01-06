using FinalCase_TosunBank.Domain.Common;

namespace FinalCase_TosunBank.Domain.Entities;

public class Department : BaseEntity<byte>
{
    public string Name { get; set; }
    public List<Authorised> Authoriseds { get; set; }
}
