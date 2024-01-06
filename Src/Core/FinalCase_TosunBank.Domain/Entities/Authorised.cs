using FinalCase_TosunBank.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalCase_TosunBank.Domain.Entities;

public class Authorised : BasePerson
{
    public byte DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public Department Department { get; set; }
}
