using DAO.Abstract;
using DAO.Common;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAO.Concrete
{
   public  class UtilisateurRepository : GenericRepository<Utilisateur, int>,  IUtilisateurRepository
    {
        public UtilisateurRepository(SyfoContext context)
            : base(context)
        {

        }
    }
}
