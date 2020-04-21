namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieCast1", "Movie_Id", "dbo.Movie");
            DropForeignKey("dbo.MovieCast1", "Cast_Id", "dbo.Cast");
            DropForeignKey("dbo.CrewMovies", "Crew_Id", "dbo.Crew");
            DropForeignKey("dbo.CrewMovies", "Movie_Id", "dbo.Movie");
            DropForeignKey("dbo.UserMovies", "User_Id", "dbo.User");
            DropForeignKey("dbo.UserMovies", "Movie_Id", "dbo.Movie");
            DropIndex("dbo.MovieCast1", new[] { "Movie_Id" });
            DropIndex("dbo.MovieCast1", new[] { "Cast_Id" });
            DropIndex("dbo.CrewMovies", new[] { "Crew_Id" });
            DropIndex("dbo.CrewMovies", new[] { "Movie_Id" });
            DropIndex("dbo.UserMovies", new[] { "User_Id" });
            DropIndex("dbo.UserMovies", new[] { "Movie_Id" });
            AddColumn("dbo.Movie", "Cast_Id", c => c.Int());
            AddColumn("dbo.Movie", "Crew_Id", c => c.Int());
            CreateIndex("dbo.Movie", "Cast_Id");
            CreateIndex("dbo.Movie", "Crew_Id");
            AddForeignKey("dbo.Movie", "Cast_Id", "dbo.Cast", "Id");
            AddForeignKey("dbo.Movie", "Crew_Id", "dbo.Crew", "Id");
            DropTable("dbo.MovieCast1");
            DropTable("dbo.CrewMovies");
            DropTable("dbo.UserMovies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserMovies",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Movie_Id });
            
            CreateTable(
                "dbo.CrewMovies",
                c => new
                    {
                        Crew_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Crew_Id, t.Movie_Id });
            
            CreateTable(
                "dbo.MovieCast1",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Cast_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Cast_Id });
            
            DropForeignKey("dbo.Movie", "Crew_Id", "dbo.Crew");
            DropForeignKey("dbo.Movie", "Cast_Id", "dbo.Cast");
            DropIndex("dbo.Movie", new[] { "Crew_Id" });
            DropIndex("dbo.Movie", new[] { "Cast_Id" });
            DropColumn("dbo.Movie", "Crew_Id");
            DropColumn("dbo.Movie", "Cast_Id");
            CreateIndex("dbo.UserMovies", "Movie_Id");
            CreateIndex("dbo.UserMovies", "User_Id");
            CreateIndex("dbo.CrewMovies", "Movie_Id");
            CreateIndex("dbo.CrewMovies", "Crew_Id");
            CreateIndex("dbo.MovieCast1", "Cast_Id");
            CreateIndex("dbo.MovieCast1", "Movie_Id");
            AddForeignKey("dbo.UserMovies", "Movie_Id", "dbo.Movie", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserMovies", "User_Id", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CrewMovies", "Movie_Id", "dbo.Movie", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CrewMovies", "Crew_Id", "dbo.Crew", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieCast1", "Cast_Id", "dbo.Cast", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieCast1", "Movie_Id", "dbo.Movie", "Id", cascadeDelete: true);
        }
    }
}
