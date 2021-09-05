namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_admin_migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropColumn("dbo.Admins", "AdmninPassword");
            DropColumn("dbo.Admins", "AdmninRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdmninRole", c => c.String(maxLength: 1));
            AddColumn("dbo.Admins", "AdmninPassword", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminRole");
            DropColumn("dbo.Admins", "AdminPassword");
        }
    }
}
