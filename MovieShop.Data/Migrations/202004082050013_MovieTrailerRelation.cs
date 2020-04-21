namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieTrailerRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trailers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrailerUrl = c.String(maxLength: 2084),
                        Name = c.String(maxLength: 2084),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trailers", "MovieId", "dbo.Movie");
            DropIndex("dbo.Trailers", new[] { "MovieId" });
            DropTable("dbo.Trailers");
        }
    }
}
