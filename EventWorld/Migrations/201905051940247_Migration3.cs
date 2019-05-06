namespace EventWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        EventChosen_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Events", t => t.EventChosen_EventId)
                .Index(t => t.EventChosen_EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "EventChosen_EventId", "dbo.Events");
            DropIndex("dbo.Carts", new[] { "EventChosen_EventId" });
            DropTable("dbo.Carts");
        }
    }
}
