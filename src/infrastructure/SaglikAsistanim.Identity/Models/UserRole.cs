using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Identity.Models;

public class UserRole
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
}
