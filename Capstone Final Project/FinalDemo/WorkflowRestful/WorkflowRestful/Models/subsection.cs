//A subsection belongs to a section
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WorkflowRestful.Models;

namespace WorkflowRestful.Models
{
    public class Subsection
    {
        // PK dependent on section creation
        public int Id { get; set; }
        //content of the subsection
        [Required]
        public string Text { get; set; }
        //relative order of the subsection compared to the other subsections under the same section
        [Required]
        public int Order { get; set; }


        //the section that the Substection belongs to
        public virtual Section Section { get; set; }


        //The template applied to the subsection
        public virtual Template Template { get; set; }
    }
    
}