namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtabletblFileInfoData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFileInfoData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(nullable: false, maxLength: 255),
                        CountWords = c.Int(nullable: false),
                        ReverseWordText = c.String(nullable: false, maxLength: 4000),
                        OriginText = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblFileInfoData");
        }
    }
}
