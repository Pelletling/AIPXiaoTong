namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl84 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuangDaArea",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 16),
                        Name = c.String(nullable: false, maxLength: 32),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.GuangDaArea", new[] { "Code" });
            DropTable("dbo.GuangDaArea");
        }
    }
}
