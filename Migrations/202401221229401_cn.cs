namespace UploadAndDisplayImageInMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "Description", c => c.String());
        }
    }
}
