namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SYSTEM.Albums",
                c => new
                    {
                        AlbumId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        GenreId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ArtistId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Title = c.String(nullable: false, maxLength: 160),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlbumArtUrl = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("SYSTEM.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("SYSTEM.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "SYSTEM.Artists",
                c => new
                    {
                        ArtistId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 160),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "SYSTEM.Genres",
                c => new
                    {
                        GenreId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 160),
                        Description = c.String(maxLength: 160),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "SYSTEM.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        OrderId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        AlbumId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Quantity = c.Decimal(nullable: false, precision: 10, scale: 0),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("SYSTEM.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("SYSTEM.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "SYSTEM.Orders",
                c => new
                    {
                        OrderId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Username = c.String(maxLength: 500),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 24),
                        Email = c.String(nullable: false, maxLength: 255),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "SYSTEM.Carts",
                c => new
                    {
                        RecordId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CartId = c.String(maxLength: 1000),
                        AlbumId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Count = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("SYSTEM.Albums", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("SYSTEM.Carts", "AlbumId", "SYSTEM.Albums");
            DropForeignKey("SYSTEM.OrderDetails", "OrderId", "SYSTEM.Orders");
            DropForeignKey("SYSTEM.OrderDetails", "AlbumId", "SYSTEM.Albums");
            DropForeignKey("SYSTEM.Albums", "GenreId", "SYSTEM.Genres");
            DropForeignKey("SYSTEM.Albums", "ArtistId", "SYSTEM.Artists");
            DropIndex("SYSTEM.Carts", new[] { "AlbumId" });
            DropIndex("SYSTEM.OrderDetails", new[] { "AlbumId" });
            DropIndex("SYSTEM.OrderDetails", new[] { "OrderId" });
            DropIndex("SYSTEM.Albums", new[] { "ArtistId" });
            DropIndex("SYSTEM.Albums", new[] { "GenreId" });
            DropTable("SYSTEM.Carts");
            DropTable("SYSTEM.Orders");
            DropTable("SYSTEM.OrderDetails");
            DropTable("SYSTEM.Genres");
            DropTable("SYSTEM.Artists");
            DropTable("SYSTEM.Albums");
        }
    }
}
