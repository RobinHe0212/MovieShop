namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class completeRelation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Trailers", newName: "Trailer");
            CreateTable(
                "dbo.Cast",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Gender = c.String(),
                        TmbdUrl = c.String(),
                        ProfilePath = c.String(maxLength: 2084),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Crew",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Gender = c.String(),
                        TmdbUrl = c.String(),
                        ProfilePath = c.String(maxLength: 2084),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 128),
                        LastName = c.String(maxLength: 128),
                        DateOfBirth = c.DateTime(precision: 7, storeType: "datetime2"),
                        Email = c.String(maxLength: 256),
                        HashedPassword = c.String(maxLength: 1024),
                        Salt = c.String(maxLength: 1024),
                        PhoneNumber = c.String(maxLength: 16),
                        TwoFactorEnabled = c.Boolean(),
                        LockoutEndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        LastLoginDateTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsLocked = c.Boolean(),
                        AccessFailedCount = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Favorite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MovieCrew",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        CrewId = c.Int(nullable: false),
                        Department = c.String(nullable: false, maxLength: 128),
                        Job = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MovieId, t.CrewId, t.Department, t.Job })
                .ForeignKey("dbo.Crew", t => t.CrewId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CrewId);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PurchaseNumber = c.Guid(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Rating = c.Decimal(nullable: false, precision: 3, scale: 2),
                        ReviewText = c.String(),
                    })
                .PrimaryKey(t => new { t.MovieId, t.UserId })
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MovieCasts",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Cast_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Cast_Id })
                .ForeignKey("dbo.Movie", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cast", t => t.Cast_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Cast_Id);
            
            CreateTable(
                "dbo.CrewMovies",
                c => new
                    {
                        Crew_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Crew_Id, t.Movie_Id })
                .ForeignKey("dbo.Crew", t => t.Crew_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Crew_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.UserMovies",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Movie_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            AlterColumn("dbo.Movie", "Price", c => c.Decimal(precision: 5, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "UserId", "dbo.User");
            DropForeignKey("dbo.Review", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Purchase", "UserId", "dbo.User");
            DropForeignKey("dbo.Purchase", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCrew", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCrew", "CrewId", "dbo.Crew");
            DropForeignKey("dbo.Favorite", "UserId", "dbo.User");
            DropForeignKey("dbo.Favorite", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserMovies", "Movie_Id", "dbo.Movie");
            DropForeignKey("dbo.UserMovies", "User_Id", "dbo.User");
            DropForeignKey("dbo.CrewMovies", "Movie_Id", "dbo.Movie");
            DropForeignKey("dbo.CrewMovies", "Crew_Id", "dbo.Crew");
            DropForeignKey("dbo.MovieCasts", "Cast_Id", "dbo.Cast");
            DropForeignKey("dbo.MovieCasts", "Movie_Id", "dbo.Movie");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserMovies", new[] { "Movie_Id" });
            DropIndex("dbo.UserMovies", new[] { "User_Id" });
            DropIndex("dbo.CrewMovies", new[] { "Movie_Id" });
            DropIndex("dbo.CrewMovies", new[] { "Crew_Id" });
            DropIndex("dbo.MovieCasts", new[] { "Cast_Id" });
            DropIndex("dbo.MovieCasts", new[] { "Movie_Id" });
            DropIndex("dbo.Review", new[] { "UserId" });
            DropIndex("dbo.Review", new[] { "MovieId" });
            DropIndex("dbo.Purchase", new[] { "MovieId" });
            DropIndex("dbo.Purchase", new[] { "UserId" });
            DropIndex("dbo.MovieCrew", new[] { "CrewId" });
            DropIndex("dbo.MovieCrew", new[] { "MovieId" });
            DropIndex("dbo.Favorite", new[] { "UserId" });
            DropIndex("dbo.Favorite", new[] { "MovieId" });
            AlterColumn("dbo.Movie", "Price", c => c.Decimal(precision: 18, scale: 2));
            DropTable("dbo.UserRole");
            DropTable("dbo.UserMovies");
            DropTable("dbo.CrewMovies");
            DropTable("dbo.MovieCasts");
            DropTable("dbo.Review");
            DropTable("dbo.Purchase");
            DropTable("dbo.MovieCrew");
            DropTable("dbo.Favorite");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Crew");
            DropTable("dbo.Cast");
            RenameTable(name: "dbo.Trailer", newName: "Trailers");
        }
    }
}
