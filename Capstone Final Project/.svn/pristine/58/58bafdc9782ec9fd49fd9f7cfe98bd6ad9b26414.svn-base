//Tracks changes and previous versions of a document
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkflowRestful.Models;

namespace WorkflowRestful.Models
{
    public class Revision
    {
        [Key]  // attempting to set explcit reference since EF can't seem to get the ref
        public int RevisionNumber { get; set; }
        //public DateTime? TimeStamp { get; set; }  // auto sets DateTime

       
        //public string PreviousContent { get; set; }
        //public int PreviousOrder { get; set; }

        //public virtual ICollection<Revision> PreviousRevision { get; set; }
        public virtual Document Document { get; set; }
        //public virtual ICollection<SectionRevision> SectionRevision { get; set; }
        //public virtual ICollection<SubsectionRevision> SubsectionRevision { get; set; }

    }
}