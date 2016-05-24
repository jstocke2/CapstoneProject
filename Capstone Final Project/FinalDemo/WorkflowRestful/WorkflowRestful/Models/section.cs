//A section of a document
//Each section belongs to a document and has zero or many subsections
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WorkflowRestful.Models;

namespace WorkflowRestful.Models
{
    public class Section
    {
        // PK
        public int Id { get; set; }
        // Contextual Data
        //[Required]
        public string Text { get; set; }
        [Required]
        //Relative order of the sections compared to other sections under the same document
        public int Order { get; set; }
        public string title { get; set; }
        // Nav Properties
        public virtual Document Document { get; set; }
        public virtual ICollection<Subsection> SubSection { get; set; }

        //The template applied to the section
        public virtual Template Template { get; set; }
    }


}