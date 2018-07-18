namespace InterviewHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Solutions",
                c => new
                    {
                        SolutionId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        SolutionDetails = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SolutionId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CateId = c.Int(nullable: false, identity: true),
                    CategoryName = c.String(nullable: false)
                })
                .PrimaryKey(t => t.CateId);

            CreateTable(
                "dbo.Questions",
                c => new
                {
                    QuestionId = c.Int(nullable: false, identity: true),
                    CateId = c.Int(nullable: false),
                    QuestTitle = c.String(nullable: false),
                    QuestDesc = c.String(nullable: false)
                })
                .PrimaryKey(t => t.QuestionId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
            DropTable("dbo.Questions");
            DropTable("dbo.Solutions");
        }
    }
}
