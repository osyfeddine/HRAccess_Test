namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableAgent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        CIN = c.String(),
                        sexe = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        LieuNaissance = c.DateTime(nullable: false),
                        Nationalite = c.String(),
                        SecondeNationalite = c.String(),
                        Matricule = c.String(),
                        NbrEnfants = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Agents");
        }
    }
}
