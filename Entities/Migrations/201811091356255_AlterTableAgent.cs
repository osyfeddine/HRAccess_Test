namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableAgent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agents", "LieuNaissance", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agents", "LieuNaissance", c => c.DateTime(nullable: false));
        }
    }
}
