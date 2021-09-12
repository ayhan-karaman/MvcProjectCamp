namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_message_datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageDate", c => c.DateTime(nullable: false));
        }
    }
}
