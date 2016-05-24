namespace WorkflowRestful.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {/*
            DropForeignKey("dbo.Templates", "Section_Id", "dbo.Sections");
            DropForeignKey("dbo.Templates", "SectionRevision_Id", "dbo.SectionRevisions");
            DropForeignKey("dbo.Templates", "Subsection_Id", "dbo.Subsections");
            DropForeignKey("dbo.Templates", "SubsectionRevision_Id", "dbo.SubsectionRevisions");
            //DropIndex("dbo.Templates", new[] { "Section_Id" });
            //DropIndex("dbo.Templates", new[] { "SectionRevision_Id" });
            //DropIndex("dbo.Templates", new[] { "Subsection_Id" });
            //DropIndex("dbo.Templates", new[] { "SubsectionRevision_Id" });
            AddColumn("dbo.Sections", "Template_Id", c => c.Int());
            AddColumn("dbo.Subsections", "Template_Id", c => c.Int());
            AddColumn("dbo.SectionRevisions", "Template_Id", c => c.Int());
            AddColumn("dbo.SubsectionRevisions", "Template_Id", c => c.Int());
            AddColumn("dbo.Templates", "ParagraphIndent", c => c.Single(nullable: false));
            AlterColumn("dbo.Templates", "IndentSpacing", c => c.Single(nullable: false));
            AlterColumn("dbo.Templates", "ParagraphSpacing", c => c.Single(nullable: false));
            AlterColumn("dbo.Templates", "LineSpacing", c => c.Single(nullable: false));
           // CreateIndex("dbo.Sections", "Template_Id");
            CreateIndex("dbo.Subsections", "Template_Id");
            CreateIndex("dbo.SectionRevisions", "Template_Id");
            CreateIndex("dbo.SubsectionRevisions", "Template_Id");
            AddForeignKey("dbo.Subsections", "Template_Id", "dbo.Templates", "Id");
            AddForeignKey("dbo.Sections", "Template_Id", "dbo.Templates", "Id");
            AddForeignKey("dbo.SectionRevisions", "Template_Id", "dbo.Templates", "Id");
            AddForeignKey("dbo.SubsectionRevisions", "Template_Id", "dbo.Templates", "Id");
            DropColumn("dbo.Templates", "Section_Id");
            DropColumn("dbo.Templates", "SectionRevision_Id");
            DropColumn("dbo.Templates", "Subsection_Id");
            DropColumn("dbo.Templates", "SubsectionRevision_Id");
       */ }
        
        public override void Down()
        {/*
            AddColumn("dbo.Templates", "SubsectionRevision_Id", c => c.Int());
            AddColumn("dbo.Templates", "Subsection_Id", c => c.Int());
            AddColumn("dbo.Templates", "SectionRevision_Id", c => c.Int());
            AddColumn("dbo.Templates", "Section_Id", c => c.Int());
            DropForeignKey("dbo.SubsectionRevisions", "Template_Id", "dbo.Templates");
            DropForeignKey("dbo.SectionRevisions", "Template_Id", "dbo.Templates");
            DropForeignKey("dbo.Sections", "Template_Id", "dbo.Templates");
            DropForeignKey("dbo.Subsections", "Template_Id", "dbo.Templates");
            DropIndex("dbo.SubsectionRevisions", new[] { "Template_Id" });
            DropIndex("dbo.SectionRevisions", new[] { "Template_Id" });
            DropIndex("dbo.Subsections", new[] { "Template_Id" });
            DropIndex("dbo.Sections", new[] { "Template_Id" });
            AlterColumn("dbo.Templates", "LineSpacing", c => c.Int(nullable: false));
            AlterColumn("dbo.Templates", "ParagraphSpacing", c => c.Int(nullable: false));
            AlterColumn("dbo.Templates", "IndentSpacing", c => c.Int(nullable: false));
            DropColumn("dbo.Templates", "ParagraphIndent");
            DropColumn("dbo.SubsectionRevisions", "Template_Id");
            DropColumn("dbo.SectionRevisions", "Template_Id");
            DropColumn("dbo.Subsections", "Template_Id");
            DropColumn("dbo.Sections", "Template_Id");
            CreateIndex("dbo.Templates", "SubsectionRevision_Id");
            CreateIndex("dbo.Templates", "Subsection_Id");
            CreateIndex("dbo.Templates", "SectionRevision_Id");
            CreateIndex("dbo.Templates", "Section_Id");
            AddForeignKey("dbo.Templates", "SubsectionRevision_Id", "dbo.SubsectionRevisions", "Id");
            AddForeignKey("dbo.Templates", "Subsection_Id", "dbo.Subsections", "Id");
            AddForeignKey("dbo.Templates", "SectionRevision_Id", "dbo.SectionRevisions", "Id");
            AddForeignKey("dbo.Templates", "Section_Id", "dbo.Sections", "Id");*/
        }
    }
}
