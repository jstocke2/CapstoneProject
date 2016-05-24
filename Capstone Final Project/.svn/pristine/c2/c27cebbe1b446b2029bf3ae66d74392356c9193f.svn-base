//Stores previous versions of and changes to a subseciton
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkflowRestful.Models
{
    public class SubsectionRevision
    {
        //Unique Id
        public int Id { get; set; }
        //The previous content of the subsection
        [Required]
        public string PreviousContent {get; set;}
        //The previous order of the subsection
        [Required]
        public int PreviousOrder { get; set; }
        public DateTime? TimeStamp { get; set; }
        
        //The subseciton that was modified
        public virtual Subsection Subsection { get; set; }
        //The revisions that the subsection applys to
        public virtual ICollection<Revision> Revision { get; set; }
        //The template applied to the subsection for the revision
        public virtual Template Template { get; set; }
    }
}