//Model for a user's document
//every document has multiple sections
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorkflowRestful.Models
{
    public class Document
    {
        //Unique Id
        public int Id { get; set; }
        //The current revision of the document
        [Required]
        public int RevisionNumber { get; set; }
        
        // stores list of sections used in the Doc
        public virtual ICollection<Section> Section { get; set; }

        

    }
}