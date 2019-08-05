namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeDepartment",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 16),
                        ParentID = c.Long(),
                        Status = c.Int(nullable: false, defaultValue: 0),
                        CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeeDepartment", t => t.ParentID)
                .Index(t => t.Name, unique: true)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.EmployeeRole",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 16),
                        Menus = c.String(),
                        MenuActions = c.String(),
                        Status = c.Int(nullable: false, defaultValue: 0),
                        CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);
            
            AddColumn("dbo.Employee", "EmployeeRoleID", c => c.Long());
            AddColumn("dbo.Employee", "EmployeeDepartmentID", c => c.Long());
            CreateIndex("dbo.Employee", "EmployeeRoleID");
            CreateIndex("dbo.Employee", "EmployeeDepartmentID");
            AddForeignKey("dbo.Employee", "EmployeeDepartmentID", "dbo.EmployeeDepartment", "ID");
            AddForeignKey("dbo.Employee", "EmployeeRoleID", "dbo.EmployeeRole", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "EmployeeRoleID", "dbo.EmployeeRole");
            DropForeignKey("dbo.Employee", "EmployeeDepartmentID", "dbo.EmployeeDepartment");
            DropForeignKey("dbo.EmployeeDepartment", "ParentID", "dbo.EmployeeDepartment");
            DropIndex("dbo.EmployeeRole", new[] { "Name" });
            DropIndex("dbo.EmployeeDepartment", new[] { "ParentID" });
            DropIndex("dbo.EmployeeDepartment", new[] { "Name" });
            DropIndex("dbo.Employee", new[] { "EmployeeDepartmentID" });
            DropIndex("dbo.Employee", new[] { "EmployeeRoleID" });
            DropColumn("dbo.Employee", "EmployeeDepartmentID");
            DropColumn("dbo.Employee", "EmployeeRoleID");
            DropTable("dbo.EmployeeRole");
            DropTable("dbo.EmployeeDepartment");
        }
    }
}
