//Interface for managing and storing the database context
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowRestful.Models
{
    public interface IWorkflowRestfulContext : IDisposable
    {
        DbSet<Section> Sections { get; }
        DbSet<Subsection> Subsections { get; }
        DbSet<Document> Documents { get; }
        DbSet<Template> Templates { get; }
        DbSet<Revision> Revisions { get; }
        DbSet<SectionRevision> SectionRevisions { get; }
        DbSet <SubsectionRevision> SubsectionRevisions { get; }
        DbSet <Font> Fonts { get; }


        int SaveChanges();


        void MarkAsModified(Section item);
        void MarkAsModified(Subsection item);
        void MarkAsModified(Document item);
        void MarkAsModified(Template item);
        void MarkAsModified(Revision item);
        void MarkAsModified(SectionRevision item);
        void MarkAsModified(SubsectionRevision item);
        void MarkAsModified(Font item);



    }
}
