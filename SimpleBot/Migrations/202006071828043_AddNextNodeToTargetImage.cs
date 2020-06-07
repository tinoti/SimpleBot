namespace SimpleBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNextNodeToTargetImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TargetImages", "NextNode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TargetImages", "NextNode");
        }
    }
}
