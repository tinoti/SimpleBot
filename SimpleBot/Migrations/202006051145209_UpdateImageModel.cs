namespace SimpleBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImageModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Name", c => c.String());
            AddColumn("dbo.Images", "Game", c => c.String());
            AddColumn("dbo.Images", "Cycle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Cycle");
            DropColumn("dbo.Images", "Game");
            DropColumn("dbo.Images", "Name");
        }
    }
}
