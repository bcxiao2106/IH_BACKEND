using InterviewHelper.Interfaces;
using InterviewHelper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InterviewHelper.Repositories
{
    public class SolutionRepository : Repository<Solution>, ISolution
    {
        public SolutionRepository(InterviewEF dbContext) : base(dbContext)
        {

        }
    }
}