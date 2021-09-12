namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_message_mg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "DeleteStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "DeleteStatus", c => c.String(maxLength: 5));
        }
    }
}
