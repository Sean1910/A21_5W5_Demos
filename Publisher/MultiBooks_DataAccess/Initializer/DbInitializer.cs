using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MultiBooks_DataAccess.Data;
using MultiBooks_Models;
using MultiBooks_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBooks_DataAccess.Initializer
{
  public class DbInitializer : IDbInitializer
  {

    private readonly MultiBooksDbContext _db;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public DbInitializer(MultiBooksDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      _db = db;
      _roleManager = roleManager;
      _userManager = userManager;
    }



    public void Initialize()
    {
      try
      {
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
          _db.Database.Migrate();
        }
      }
      catch (Exception ex)
      {

      }

      if (_db.Roles.Any(r => r.Name == AppConst.AdminRole)) return;

      _roleManager.CreateAsync(new IdentityRole(AppConst.AdminRole)).GetAwaiter().GetResult();
      // Autres roles

      _userManager.CreateAsync(new ApplicationUser
      {
        UserName = "valerie.turgeon@cegepmontpetit.ca",
        Email = "valerie.turgeon@cegepmontpetit.ca",
        EmailConfirmed = true,
        NickName = "AdminJungle",
        PhoneNumber = "111111111111"
      }, "Jungle1234*").GetAwaiter().GetResult();

      ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.Email == "valerie.turgeon@cegepmontpetit.ca");
      _userManager.AddToRoleAsync(user, AppConst.AdminRole).GetAwaiter().GetResult();

    }
  }
}
