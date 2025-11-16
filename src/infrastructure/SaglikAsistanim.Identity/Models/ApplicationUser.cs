using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Identity.Models;

public class ApplicationUser : IdentityUser<string>
{
    public ApplicationUser()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
