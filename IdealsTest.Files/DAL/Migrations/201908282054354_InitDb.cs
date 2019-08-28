namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileInfo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 400),
                        Index = c.String(maxLength: 100),
                        Size = c.Long(nullable: false),
                        Category = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.Id);

            CreateIndex(
                "dbo.FileInfo",
                "Index",
                name: "UI_FileInfo_Index",
                unique: true);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileInfo");
        }
    }
}
