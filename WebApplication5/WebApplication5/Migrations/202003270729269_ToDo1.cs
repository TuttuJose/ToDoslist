namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Todos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        isDone = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todos", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Todos", new[] { "User_Id" });
            DropTable("dbo.Todos");
        }
    }
}
