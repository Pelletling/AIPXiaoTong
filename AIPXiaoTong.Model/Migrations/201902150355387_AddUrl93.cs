namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl93 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountPingAn",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Long(nullable: false),
                        Mobile = c.String(maxLength: 11),
                        IdExpiredDate = c.DateTime(),
                        IDImageFront = c.String(maxLength: 128),
                        IDImageOpposite = c.String(maxLength: 128),
                        Status = c.Int(nullable: false,defaultValue:0),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Member", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountPingAn", "MemberID", "dbo.Member");
            DropIndex("dbo.AccountPingAn", new[] { "MemberID" });
            DropTable("dbo.AccountPingAn");
        }
    }
}
