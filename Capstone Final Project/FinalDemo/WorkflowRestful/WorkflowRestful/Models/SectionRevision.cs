//Stores previous version or changes to a section
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkflowRestful.Models
{
    public class SectionRevision
    {
        //Unique Id
        public int Id { get; set; }
        //The previous text of the section
        [Required]
        public string PreviousContent { get; set; }
        //The previous order of the section
        [Required]
        public int PreviousOrder { get; set; }
        //The time that the revision was saved
        public DateTime? TimeStamp { get; set; }
        //The seciton that was modified
        public virtual Section Section { get; set; }
        //The revision(s) that this subsection apply to
       public virtual ICollection<Revision> Revision { get; set; }


        //The template applied to the section for the revision
        public virtual Template Template { get; set; }
    }
}