namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("SYSTEM.Albums", "Img", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("SYSTEM.Albums", "Img");
        }
    }
}
