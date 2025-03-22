namespace Account.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActivityUsers",
                c => new
                    {
                        ActivityId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ActivityId, t.UserId })
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivityUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ActivityUsers", "ActivityId", "dbo.Activities");
            DropIndex("dbo.ActivityUsers", new[] { "UserId" });
            DropIndex("dbo.ActivityUsers", new[] { "ActivityId" });
            DropTable("dbo.ActivityUsers");
            DropTable("dbo.Activities");
        }
    }
}
