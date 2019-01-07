
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;



namespace Entities.Models
{
   public class SyfoContext: DbContext
    {
        public SyfoContext()
            : base("name=SyfoContext")
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Agent> Agent { get; set; }
    }
}
