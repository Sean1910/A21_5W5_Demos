using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBooks_Models
{
  // Hériter de IdentityUser permet d'ajouter des colonnes
  //dans la table Users
  public class ApplicationUser: IdentityUser

  {
    public string NickName { get; set; }
  }
}
