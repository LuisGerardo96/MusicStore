namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationalbumproperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("SYSTEM.Albums", "Img", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("SYSTEM.Albums", "Img", c => c.Binary());
        }
    }
}
