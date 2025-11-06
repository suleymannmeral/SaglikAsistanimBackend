using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SaglikAsistanim.Identity.Models;

public class Role : IdentityRole<string>
{
    public string? Description { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}