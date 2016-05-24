//Defines the database and what can be stored there
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WorkflowRestful.Models;

namespace WorkflowRestful.Models
{
    public class WorkflowRestfulContext : IdentityDbContext<ApplicationUser>, IWorkflowRestfulContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        //Selects the WorkflowRestfulContext connection string from the config file
        public WorkflowRestfulContext() : base("name=WorkflowRestfulContext")
        {
            
            //// logs database data written
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            //// allow automatic code first migrations
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WorkflowRestfulContext, WorkflowRestful.Migrations.Configuration>("WorkFlowRestfulContext"));
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static WorkflowRestfulContext Create()
        {
            return new WorkflowRestfulContext();
        }

        public System.Data.Entity.DbSet<WorkflowRestful.Models.Section> Sections { get; set; }
        public void MarkAsModified(Section item)
        {
            Entry(item).State = EntityState.Modified;
        }


        public System.Data.Entity.DbSet<WorkflowRestful.Models.Subsection> Subsections { get; set; }
        public void MarkAsModified(Subsection item)
        {
            Entry(item).State = EntityState.Modified;
        }


        public System.Data.Entity.DbSet<WorkflowRestful.Models.Document> Documents { get; set; }
        public void MarkAsModified(Document item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public System.Data.Entity.DbSet<WorkflowRestful.Models.Template> Templates { get; set; }
        public void MarkAsModified(Template item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public System.Data.Entity.DbSet<WorkflowRestful.Models.Revision> Revisions { get; set; }
        public void MarkAsModified(Revision item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public System.Data.Entity.DbSet<WorkflowRestful.Models.SectionRevision> SectionRevisions { get; set; }
        public void MarkAsModified(SectionRevision item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public System.Data.Entity.DbSet<WorkflowRestful.Models.SubsectionRevision> SubsectionRevisions { get; set; }
        public void MarkAsModified(SubsectionRevision item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public System.Data.Entity.DbSet<WorkflowRestful.Models.Font> Fonts { get; set; }
        public void MarkAsModified(Font item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}
