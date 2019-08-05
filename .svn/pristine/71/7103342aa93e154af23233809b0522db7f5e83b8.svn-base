namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl65 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaGuangDa",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 8),
                        Name = c.String(nullable: false, maxLength: 16),
                        ParentCode = c.String(maxLength: 8),
                        Level = c.Int(nullable: false),
                        ID = c.Long(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.AreaGuangDa", t => t.ParentCode)
                .Index(t => t.Code, unique: true)
                .Index(t => t.ParentCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AreaGuangDa", "ParentCode", "dbo.AreaGuangDa");
            DropIndex("dbo.AreaGuangDa", new[] { "ParentCode" });
            DropIndex("dbo.AreaGuangDa", new[] { "Code" });
            DropTable("dbo.AreaGuangDa");
        }
    }
}
