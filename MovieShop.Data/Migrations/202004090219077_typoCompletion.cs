namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typoCompletion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cast", "TmdbUrl", c => c.String());
            DropColumn("dbo.Cast", "TmbdUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cast", "TmbdUrl", c => c.String());
            DropColumn("dbo.Cast", "TmdbUrl");
        }
    }
}
