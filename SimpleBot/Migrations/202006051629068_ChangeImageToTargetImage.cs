namespace SimpleBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeImageToTargetImage : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Images", newName: "TargetImages");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TargetImages", newName: "Images");
        }
    }
}
