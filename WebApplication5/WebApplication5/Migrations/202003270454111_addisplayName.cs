namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addisplayName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "displyName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "displyName", c => c.String(nullable: false));
        }
    }
}
