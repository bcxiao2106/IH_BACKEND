using InterviewHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewHelper.DTOs
{
    public class FullListDTO
    {
        public int QuestionId { get; set; }
        public int CateId { get; set; }
        public string QuestTitle { get; set; }
        public string QuestDesc { get; set; }
        public Category Category { get; set; }
        public List<Solution> SolutionList { get; set; }
    }
}