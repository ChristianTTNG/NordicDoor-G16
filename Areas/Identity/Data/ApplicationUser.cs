using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NordicDoorApplication.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
// Ansatt
public class ApplicationUser : IdentityUser
{
    public int EmployeeNumber { get; set; }
    public string EmpName { get; set; }
}

public class ApplicationRole : IdentityRole
{

}