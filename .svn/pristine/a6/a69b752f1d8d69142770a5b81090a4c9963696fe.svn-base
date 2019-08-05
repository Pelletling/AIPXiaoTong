namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUrl6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeMenu",
                c => new
                {
                    Code = c.String(nullable: false, maxLength: 16),
                    Name = c.String(nullable: false, maxLength: 16),
                    Url = c.String(maxLength: 64),
                    ParentCode = c.String(maxLength: 16),
                    Sort = c.Int(nullable: false, defaultValue: 0),
                    Controller = c.String(maxLength: 64),
                    Action = c.String(maxLength: 64),
                    ID = c.Long(nullable: false, identity: true),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.EmployeeMenu", t => t.ParentCode)
                .Index(t => t.Code, unique: true)
                .Index(t => t.ParentCode);

            CreateTable(
                "dbo.EmployeeMenuAction",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    MenuCode = c.String(nullable: false, maxLength: 16),
                    Code = c.String(nullable: false, maxLength: 32),
                    Name = c.String(nullable: false, maxLength: 16),
                    Sort = c.Int(nullable: false, defaultValue: 0),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeeMenu", t => t.MenuCode, cascadeDelete: true)
                .Index(t => new { t.MenuCode, t.Code }, unique: true, name: "EmployeeMenuAction_IX");

        }

        public override void Down()
        {
            DropForeignKey("dbo.EmployeeMenu", "ParentCode", "dbo.EmployeeMenu");
            DropForeignKey("dbo.EmployeeMenuAction", "MenuCode", "dbo.EmployeeMenu");
            DropIndex("dbo.EmployeeMenuAction", "EmployeeMenuAction_IX");
            DropIndex("dbo.EmployeeMenu", new[] { "ParentCode" });
            DropIndex("dbo.EmployeeMenu", new[] { "Code" });
            DropTable("dbo.EmployeeMenuAction");
            DropTable("dbo.EmployeeMenu");
        }
    }
}
