namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl47 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankCard",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Long(nullable: false),
                        BankCardNumber = c.String(nullable: false, maxLength: 32),
                        BankName = c.String(nullable: false, maxLength: 32),
                        SubBranchName = c.String(nullable: false, maxLength: 32),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Member", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankCard", "MemberID", "dbo.Member");
            DropIndex("dbo.BankCard", new[] { "MemberID" });
            DropTable("dbo.BankCard");
        }
    }
}
