using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InterviewHelper.Models
{
    public class Question
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QuestionId { get; set; }
        [Required]
        public int CateId { get; set; }
        [Required]
        public string QuestTitle { get; set; }
        public string QuestDesc { get; set; }
    }
}