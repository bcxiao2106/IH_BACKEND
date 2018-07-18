using InterviewHelper.Interfaces;
using InterviewHelper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InterviewHelper.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestion
    {
        public QuestionRepository(InterviewEF dbContext) : base(dbContext)
        {
        }
    }
}