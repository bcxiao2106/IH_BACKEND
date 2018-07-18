using InterviewHelper.Interfaces;
using InterviewHelper.Models;
using System.Data.Entity;

namespace InterviewHelper.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategory
    {
        public CategoryRepository(InterviewEF dbContext) 
            : base(dbContext)
        {
           
        }
    }
}