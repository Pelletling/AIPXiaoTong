namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Role", "CreateUserID", "dbo.Users");
            DropForeignKey("dbo.Role", "ModifyUserID", "dbo.Users");
            DropForeignKey("dbo.Department", "CreateUserID", "dbo.Users");
            DropForeignKey("dbo.Department", "ModifyUserID", "dbo.Users");
            DropIndex("dbo.Department", new[] { "CreateUserID" });
            DropIndex("dbo.Department", new[] { "ModifyUserID" });
            DropIndex("dbo.Role", new[] { "CreateUserID" });
            DropIndex("dbo.Role", new[] { "ModifyUserID" });
            DropColumn("dbo.Department", "CreateUserID");
            DropColumn("dbo.Department", "ModifyUserID");
            DropColumn("dbo.Role", "CreateUserID");
            DropColumn("dbo.Role", "ModifyUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Role", "ModifyUserID", c => c.Long());
            AddColumn("dbo.Role", "CreateUserID", c => c.Long(nullable: false));
            AddColumn("dbo.Department", "ModifyUserID", c => c.Long());
            AddColumn("dbo.Department", "CreateUserID", c => c.Long(nullable: false));
            CreateIndex("dbo.Role", "ModifyUserID");
            CreateIndex("dbo.Role", "CreateUserID");
            CreateIndex("dbo.Department", "ModifyUserID");
            CreateIndex("dbo.Department", "CreateUserID");
            AddForeignKey("dbo.Department", "ModifyUserID", "dbo.Users", "ID");
            AddForeignKey("dbo.Department", "CreateUserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Role", "ModifyUserID", "dbo.Users", "ID");
            AddForeignKey("dbo.Role", "CreateUserID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
