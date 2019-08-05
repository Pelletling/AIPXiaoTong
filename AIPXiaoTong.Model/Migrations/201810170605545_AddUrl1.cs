namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUrl1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 16),
                    ParentID = c.Long(),
                    CreateUserID = c.Long(nullable: false),
                    ModifyUserID = c.Long(),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.ParentID)
                .ForeignKey("dbo.Users", t => t.CreateUserID)
                .ForeignKey("dbo.Users", t => t.ModifyUserID)
                .Index(t => t.Name, unique: true)
                .Index(t => t.ParentID)
                .Index(t => t.CreateUserID)
                .Index(t => t.ModifyUserID);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    Code = c.String(nullable: false, maxLength: 16),
                    Name = c.String(nullable: false, maxLength: 32),
                    Email = c.String(maxLength: 64),
                    Password = c.String(nullable: false, maxLength: 32),
                    IsMort = c.Int(nullable: false, defaultValue: 0),
                    LastLoginDate = c.DateTime(),
                    RoleID = c.Long(),
                    DepartmentID = c.Long(),
                    AuthDepartmentIDs = c.String(),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.RoleID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.RoleID)
                .Index(t => t.DepartmentID);

            CreateTable(
                "dbo.Role",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 16),
                    Menus = c.String(),
                    MenuActions = c.String(),
                    CreateUserID = c.Long(nullable: false),
                    ModifyUserID = c.Long(),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.CreateUserID)
                .ForeignKey("dbo.Users", t => t.ModifyUserID)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CreateUserID)
                .Index(t => t.ModifyUserID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Users", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Department", "ModifyUserID", "dbo.Users");
            DropForeignKey("dbo.Department", "CreateUserID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Role");
            DropForeignKey("dbo.Role", "ModifyUserID", "dbo.Users");
            DropForeignKey("dbo.Role", "CreateUserID", "dbo.Users");
            DropForeignKey("dbo.Department", "ParentID", "dbo.Department");
            DropIndex("dbo.Role", new[] { "ModifyUserID" });
            DropIndex("dbo.Role", new[] { "CreateUserID" });
            DropIndex("dbo.Role", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "DepartmentID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Users", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "Code" });
            DropIndex("dbo.Department", new[] { "ModifyUserID" });
            DropIndex("dbo.Department", new[] { "CreateUserID" });
            DropIndex("dbo.Department", new[] { "ParentID" });
            DropIndex("dbo.Department", new[] { "Name" });
            DropTable("dbo.Role");
            DropTable("dbo.Users");
            DropTable("dbo.Department");
        }
    }
}
