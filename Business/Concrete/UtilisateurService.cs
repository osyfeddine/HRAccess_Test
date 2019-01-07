using Business.Abstract;
using Business.Common;
using DAO.Abstract;
using DAO.Common;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UtilisateurService : EntityService<Utilisateur, int>, IUtilisateurService
    {

        public UtilisateurService(IUnitOfWork unitOfWork,
            IUtilisateurRepository utilisateurRepository)
            : base(unitOfWork, utilisateurRepository)
        {


        }
    }
}
