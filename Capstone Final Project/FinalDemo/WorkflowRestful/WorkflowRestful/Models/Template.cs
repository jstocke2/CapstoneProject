//Templates are applied to sections and subsections to format them
//The spacing measurements are to be decided later
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WorkflowRestful.Models;

namespace WorkflowRestful.Models
{
    public class Template
    {
        //Unique Id
        public int Id { get; set; }
        //The id of the font that the template uses
        [Required]
        public int FontId { get; set; }
        //The indent of all lines
        [Required]
        public float IndentSpacing { get; set; }
        //The space between paragraphs
        [Required]
        public float ParagraphSpacing { get; set; }
        //The space between lines inside of a paragraph
        [Required]
        public float LineSpacing { get; set; }
        //The indent at the begining of a paragraph
        [Required]
        public float ParagraphIndent { get; set; }

        public virtual ICollection <Font> Font { get; set; }
    }
}