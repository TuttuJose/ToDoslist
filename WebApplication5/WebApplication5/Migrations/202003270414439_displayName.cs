namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class displayName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "displyName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "displyName");
        }
    }
}
