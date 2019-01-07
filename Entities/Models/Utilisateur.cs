using DAO.Common;
using System;

namespace Entities.Models
{
    public partial class Utilisateur : Entity<int> 
    {
       
        public string NomComplet { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
