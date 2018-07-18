using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using InterviewHelper.Models;
using InterviewHelper.UOW;

namespace InterviewHelper.Controllers
{
    public class SolutionsController : ApiController
    {
        private InterviewEF db = new InterviewEF();
        private UnitOfWork _unitOfWork;

        public SolutionsController()
        {
            this._unitOfWork = new UnitOfWork(new InterviewEF());
        }

        // GET: api/Solutions
        public IEnumerable<Solution> GetSolutions()
        {
            return this._unitOfWork.solutionRepository.GetAll();
        }

        // GET: api/Solutions/5
        [ResponseType(typeof(Solution))]
        public IHttpActionResult GetSolution(int id)
        {
            Solution solution = this._unitOfWork.solutionRepository.Get(id);
            if (solution == null)
            {
                return NotFound();
            }

            return Ok(solution);
        }

        // PUT: api/Solutions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSolution(int id, Solution solution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solution.SolutionId)
            {
                return BadRequest();
            }

            db.Entry(solution).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolutionExists(id))
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

        // POST: api/Solutions
        [ResponseType(typeof(Solution))]
        public IHttpActionResult PostSolution(Solution solution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this._unitOfWork.solutionRepository.Add(solution);
            this._unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = solution.SolutionId }, solution);
        }

        // DELETE: api/Solutions/5
        [ResponseType(typeof(Solution))]
        public IHttpActionResult DeleteSolution(int id)
        {
            Solution solution = db.Solutions.Find(id);
            if (solution == null)
            {
                return NotFound();
            }

            this._unitOfWork.solutionRepository.Remove(solution);
            this._unitOfWork.Complete();

            return Ok(solution);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolutionExists(int id)
        {
            return this._unitOfWork.solutionRepository.GetAll().Count(e => e.SolutionId == id) > 0;
        }
    }
}