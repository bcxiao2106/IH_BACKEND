using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InterviewHelper;
using InterviewHelper.Models;
using InterviewHelper.UOW;

namespace InterviewHelper.Controllers
{
    public class CategoriesController : ApiController
    {
        private InterviewEF db = new InterviewEF();
        private UnitOfWork _unitOfWork;

        public CategoriesController()
        {
            this._unitOfWork = new UnitOfWork(new InterviewEF());
        }

        // GET: api/Categories
        public IEnumerable<Category> GetCategories()
        {
            return this._unitOfWork.categoryRepository.GetAll();
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = this._unitOfWork.categoryRepository.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CateId)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this._unitOfWork.categoryRepository.Add(category);
            this._unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = category.CateId }, category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = this._unitOfWork.categoryRepository.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            this._unitOfWork.categoryRepository.Remove(category);
            this._unitOfWork.Complete();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return this._unitOfWork.categoryRepository.GetAll().Count(e => e.CateId == id) > 0;
        }
    }
}