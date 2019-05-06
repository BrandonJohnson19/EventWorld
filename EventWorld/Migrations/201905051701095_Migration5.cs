namespace EventWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Type_EventTypeId", c => c.Int());
            CreateIndex("dbo.Events", "Type_EventTypeId");
            AddForeignKey("dbo.Events", "Type_EventTypeId", "dbo.EventTypes", "EventTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Type_EventTypeId", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "Type_EventTypeId" });
            DropColumn("dbo.Events", "Type_EventTypeId");
        }
    }
}
