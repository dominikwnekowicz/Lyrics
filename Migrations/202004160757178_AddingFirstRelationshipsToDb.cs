namespace Lyrics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFirstRelationshipsToDb : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Comments", "LyricId");
            CreateIndex("dbo.Lyrics", "GenreId");
            AddForeignKey("dbo.Lyrics", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "LyricId", "dbo.Lyrics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "LyricId", "dbo.Lyrics");
            DropForeignKey("dbo.Lyrics", "GenreId", "dbo.Genres");
            DropIndex("dbo.Lyrics", new[] { "GenreId" });
            DropIndex("dbo.Comments", new[] { "LyricId" });
        }
    }
}
