using InterviewHelper.Interfaces;
using InterviewHelper.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InterviewHelper.UOW
{
    public class UnitOfWork
    {
        private InterviewEF Context;
        private ICategory _categoryRepository;
        private IQuestion _questionRepository;
        private ISolution _solutionRepository;
        private bool disposed = false;

        public UnitOfWork(InterviewEF dbContext)
        {
            this.Context = dbContext;
        }

        public ICategory categoryRepository
        {
            get
            {
                if(_categoryRepository == null)
                {
                    this._categoryRepository = new CategoryRepository(this.Context);
                }
                return this._categoryRepository;
            }
        }

        public IQuestion questionRepository
        {
            get
            {
                if (_questionRepository == null)
                {
                    this._questionRepository = new QuestionRepository(this.Context);
                }
                return this._questionRepository;
            }
        }

        public ISolution solutionRepository
        {
            get
            {
                if (_solutionRepository == null)
                {
                    this._solutionRepository = new SolutionRepository(this.Context);
                }
                return this._solutionRepository;
            }
        }

        public int Complete()
        {
            return this.Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}