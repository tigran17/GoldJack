namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoldJack_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "PersonalId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PersonalId", c => c.Int(nullable: false));
        }
    }
}
