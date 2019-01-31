namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoldJack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        IsOpened = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Bet = c.Double(nullable: false),
                        Range = c.String(),
                        IsWin = c.Boolean(nullable: false),
                        IsCashback = c.Boolean(nullable: false),
                        IsBonusGame = c.Boolean(nullable: false),
                        GameNumber = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalId = c.Int(nullable: false),
                        Name = c.String(),
                        Surename = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameDetails", "GameId", "dbo.Games");
            DropForeignKey("dbo.Coins", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "UserId", "dbo.Users");
            DropIndex("dbo.GameDetails", new[] { "GameId" });
            DropIndex("dbo.Games", new[] { "UserId" });
            DropIndex("dbo.Coins", new[] { "GameId" });
            DropTable("dbo.GameDetails");
            DropTable("dbo.Users");
            DropTable("dbo.Games");
            DropTable("dbo.Coins");
        }
    }
}
