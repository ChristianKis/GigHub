namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollows : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ArtistId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.ArtistId })
                .ForeignKey("dbo.AspNetUsers", t => t.ArtistId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ArtistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "ArtistId" });
            DropIndex("dbo.Follows", new[] { "UserId" });
            DropTable("dbo.Follows");
        }
    }
}
