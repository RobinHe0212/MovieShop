namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixMovieCastRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "Cast_Id", "dbo.Cast");
            DropIndex("dbo.Movie", new[] { "Cast_Id" });
            DropColumn("dbo.Movie", "Cast_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "Cast_Id", c => c.Int());
            CreateIndex("dbo.Movie", "Cast_Id");
            AddForeignKey("dbo.Movie", "Cast_Id", "dbo.Cast", "Id");
        }
    }
}
