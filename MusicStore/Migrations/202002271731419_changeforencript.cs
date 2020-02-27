namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeforencript : DbMigration
    {
        public override void Up()
        {
            AlterColumn("SYSTEM.Users", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("SYSTEM.Users", "Password", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
