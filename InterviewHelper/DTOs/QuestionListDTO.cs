using InterviewHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewHelper.DTOs
{
    public class QuestionListDTO
    {
        public int QuestionId { get; set; }
        public int CateId { get; set; }
        public string QuestTitle { get; set; }
        public string QuestDesc { get; set; }
        public string CategoryName { get; set; }
        public int TotalAnswers { get; set; }
    }
}