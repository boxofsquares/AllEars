using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AllEars.Models
{
    public class QuestionModel
    {   
        [Required]
        public string body { get; set; }
        public DateTime timestamp { get; set; }
        public string nickname { get; set; }
    }
}