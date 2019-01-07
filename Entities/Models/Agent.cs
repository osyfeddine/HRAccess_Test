using DAO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public partial class Agent: Entity<int>
    {
        
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string CIN { get; set; }
        public string sexe { get; set; }
        public DateTime DateNaissance { get; set; }
        public string LieuNaissance { get; set; }
        public string Nationalite { get; set; }
        public string SecondeNationalite { get; set; }
        public string Matricule { get; set; }
        public int NbrEnfants { get; set; }

    }
}
