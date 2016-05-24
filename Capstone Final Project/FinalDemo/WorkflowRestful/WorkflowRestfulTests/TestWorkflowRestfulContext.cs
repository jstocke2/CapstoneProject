//Test context to hold test data in memory
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowRestful.Models;

namespace WorkflowRestfulTests
{
    public class TestWorkflowRestfulContext : IWorkflowRestfulContext
    {
        public TestWorkflowRestfulContext()
        {
            this.Sections = new TestSectionDbSet();
            this.Subsections = new TestSubsectionDbSet();
            this.Documents = new TestDocumentDbSet();
            this.Revisions = new TestRevisionDbSet();
            this.SectionRevisions = new TestSectionRevisionDbSet();
            this.SubsectionRevisions = new TestSubsectionRevisionDbSet();
            this.Templates = new TestTemplateDbSet();
            this.Fonts = new TestFontDbSet();
        }

        //Does not save any changes

        public int SaveChanges()
        {
            return 0;
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Subsection> Subsections { get; set; }
        public DbSet<Revision> Revisions { get; set; }
        public DbSet<SectionRevision> SectionRevisions { get; set; }
        public DbSet <SubsectionRevision> SubsectionRevisions { get; set; }
        public DbSet <Template> Templates { get; set; }
        public DbSet<Font> Fonts { get; set; }




        public void MarkAsModified(Section item) { }
        public void MarkAsModified(Subsection item) { }
        public void MarkAsModified(Document item) { }
        public void MarkAsModified(Font item) { }
        public void MarkAsModified(Revision item) { }
        public void MarkAsModified(SectionRevision item) { }
        public void MarkAsModified(SubsectionRevision item) { }
        public void MarkAsModified(Template item) { }

        public void Dispose() { }
    }
}
