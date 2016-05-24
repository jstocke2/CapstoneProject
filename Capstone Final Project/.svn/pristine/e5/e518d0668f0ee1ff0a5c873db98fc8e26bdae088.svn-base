//The model for a font with a style, size, and color
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkflowRestful.Models
{
    public class Font
    {
        //Unique fontId
        [Key]
        public int FontId { get; set; }
        //Name of the font style
        [Required]
        [MaxLength(20)]
        public string Style { get; set; }
        //The font size
        [Required]
        public int Size { get; set; }
        //The color of the font
        [Required]
        [MaxLength(15)]
        public string Color { get; set; }
        // Nav property
        //public virtual ICollection<Template> Template { get; set; }
    }
}