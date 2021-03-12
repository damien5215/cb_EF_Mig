namespace ComicBookGalleryModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCBAREntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CBAverageRating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComicBookId = c.Int(nullable: false),
                        AverageRating = c.Decimal(nullable: false, precision: 5, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComicBook", t => t.ComicBookId, cascadeDelete: true)
                .Index(t => t.ComicBookId);

            // Populate CBAverageRating Table
            Sql(
                @"
                insert into CBAverageRating
                select Id, AverageRating, getdate() from ComicBook 
                where AverageRating is not null
                ");
            
            DropColumn("dbo.ComicBook", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComicBook", "AverageRating", c => c.Decimal(precision: 5, scale: 2));

            // Populate ComicBook.AverageRating Table
            Sql(@"
                update cb
                set cb.AverageRating = cbar.AverageRating
                from ComicBook cb
                cross apply (
                    select top 1 AverageRating, Date
                    from CBAverageRating 
                    where ComicBookId = cb.Id
                    order by Date desc
                ) as cbar
            ");

            DropForeignKey("dbo.CBAverageRating", "ComicBookId", "dbo.ComicBook");
            DropIndex("dbo.CBAverageRating", new[] { "ComicBookId" });
            DropTable("dbo.CBAverageRating");
        }
    }
}
