namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleterequiredusername : DbMigration
    {
        public override void Up()
        {
            AlterColumn("SYSTEM.Users", "UserName", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("SYSTEM.Users", "UserName", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
