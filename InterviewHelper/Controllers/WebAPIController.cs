using InterviewHelper.DTOs;
using InterviewHelper.Models;
using InterviewHelper.UOW;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace InterviewHelper.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WebAPIController : ApiController
    {
        private UnitOfWork _unitOfWork;
        
        public WebAPIController()
        {
            this._unitOfWork = new UnitOfWork(new InterviewEF());
        }

        [HttpGet]
        [Route("api/QuestionList")]
        public IHttpActionResult GetQuestionList()
        {
            List<QuestionListDTO> questionList =  (from Q in this._unitOfWork.questionRepository.GetAll()
                                 join C in this._unitOfWork.categoryRepository.GetAll()
                                 on Q.CateId equals C.CateId
                                 select new QuestionListDTO { QuestionId = Q.QuestionId, CateId = C.CateId, CategoryName = C.CategoryName, QuestDesc = Q.QuestDesc, QuestTitle = Q.QuestTitle}).ToList();
            foreach (QuestionListDTO questionDto in questionList)
            {
                int questionId = questionDto.QuestionId;
                int totalAnswers = this._unitOfWork.solutionRepository.Find(s => s.QuestionId == questionId).Count<Solution>();
                questionDto.TotalAnswers = totalAnswers;
            }
            return Ok(questionList);
        }

        [HttpGet]
        [Route("api/FullList")]
        public IHttpActionResult GetFullList()
        {
            List<FullListDTO> fullList = (from Q in this._unitOfWork.questionRepository.GetAll()
                                          join C in this._unitOfWork.categoryRepository.GetAll()
                                          on Q.CateId equals C.CateId
                                          select new FullListDTO { QuestionId = Q.QuestionId, CateId = Q.CateId,
                                              QuestDesc = Q.QuestDesc, QuestTitle = Q.QuestTitle, Category = C}).ToList();
            foreach (FullListDTO fullListDTO in fullList)
            {
                int questionId = fullListDTO.QuestionId;
                List<Solution> solutionList = this._unitOfWork.solutionRepository.Find(s => s.QuestionId == questionId).ToList<Solution>();
                fullListDTO.SolutionList = solutionList;
            }
            return Ok(fullList);
        }

        [HttpPost]
        [Route("api/NewQuestion")]
        public IHttpActionResult NewQuestion(Question newQuestion)
        {
            if(this._unitOfWork.questionRepository.Add(newQuestion))
            {
                this._unitOfWork.Complete();
                return Ok(newQuestion);
            }
            else
            {
                return Ok("Error");
            }
        }

        [HttpGet]
        [Route("api/CategoryList")]
        public IHttpActionResult GetCategoryList()
        {
            List<Category> categoryList = this._unitOfWork.categoryRepository.GetAll().ToList<Category>();
            return Ok(categoryList);
        }

        [HttpGet]
        [Route("api/SolutionList")]
        public IHttpActionResult GetSolutionList(int questionId)
        {
            List<Solution> solutionList = this._unitOfWork.solutionRepository.Find(s=>s.QuestionId == questionId).ToList<Solution>();
            return Ok(solutionList);
        }

        [HttpPost]
        [Route("api/NewSolution")]
        public IHttpActionResult NewSolution(Solution newSolution)
        {
            if (this._unitOfWork.solutionRepository.Add(newSolution))
            {
                this._unitOfWork.Complete();
                return Ok(newSolution);
            }
            else
            {
                return Ok("Error");
            }
        }

        [HttpGet]
        [Route("api/GetAllQuestions")]
        public IHttpActionResult GetAllQuestions()
        {
            return Ok(this._unitOfWork.questionRepository.GetAll().ToList());
        }

        [HttpGet]
        [Route("api/GetAllCategories")]
        public IHttpActionResult GetAllCategories()
        {
            return Ok(this._unitOfWork.categoryRepository.GetAll().ToList());
        }

        [HttpGet]
        [Route("api/GetAllSolutions")]
        public IHttpActionResult GetAllSolutions()
        {
            return Ok(this._unitOfWork.solutionRepository.GetAll().ToList());
        }

    }
}
