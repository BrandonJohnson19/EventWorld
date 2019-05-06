namespace EventWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MaxTickets = c.Int(nullable: false),
                        AvailableTickets = c.Int(nullable: false),
                        Organizer = c.String(nullable: false),
                        OrganizerContactInfo = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        EventTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.EventTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
        }
    }
}
