namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "DeleteStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "DeleteStatus");
        }
    }
}
