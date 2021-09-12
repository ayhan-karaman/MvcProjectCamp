namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_message_mg1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "DeleteStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "DeleteStatus", c => c.Boolean(nullable: false));
        }
    }
}
