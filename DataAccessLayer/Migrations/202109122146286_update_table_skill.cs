namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_skill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MySkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillName = c.String(maxLength: 100),
                        Rate = c.Int(nullable: false),
                        TalentCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TalentCards", t => t.TalentCardId, cascadeDelete: true)
                .Index(t => t.TalentCardId);
            
            CreateTable(
                "dbo.TalentCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        About = c.String(maxLength: 50),
                        ProfileImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MySkills", "TalentCardId", "dbo.TalentCards");
            DropIndex("dbo.MySkills", new[] { "TalentCardId" });
            DropTable("dbo.TalentCards");
            DropTable("dbo.MySkills");
        }
    }
}
