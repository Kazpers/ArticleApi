using System;
using System.Linq;
using ArticleApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleApi.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly IDataController _dataController;

        public ApiController()
        {
            _dataController = new DataController();
        }

        [HttpGet]
        [Route("articles")]
        //[Authorize("read:article")] Disabled authentication for this test
        public IActionResult GetAllArticles()
        {
            var result = _dataController.GetAllArticles();
            return Json(result);
        }
        
        [HttpGet]
        [Route("articles/by/author/{authorId}")]
        //[Authorize("read:article")] Disabled authentication for this test
        public IActionResult GetArticlesByAuthor(string authorId)
        {
            var result = _dataController.GetArticlesByAuthor(authorId);
            return Json(result);
        }

        [HttpGet]
        [Route("article/{id}")]
        //[Authorize("read:article")] Disabled authentication for this test
        public IActionResult GetArticle(string id)
        {
            var result = _dataController.GetArticle(id);
            return Json(result);
        }

        [HttpGet]
        [Route("authors")]
        //[Authorize("read:author")] Disabled authentication for this test
        public IActionResult GetAllAuthors()
        {
            var result = _dataController.GetAllAuthors();
            return Json(result);
        }

        [HttpPost]
        [Route("article/by/author/{authorId}")]
        //[Authorize("add:article")] Disabled authentication for this test
        public IActionResult AddArticle([FromBody]Article article, string authorId)
        {
            string createdId;
            try
            {
                createdId = _dataController.AddArticle(article, authorId);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    e.Message
                });
            }
            return Json(new
            {
                Message = $"Article ({createdId}) successfully added"
            });
        }

        [HttpDelete]
        [Route("article/{articleId}")]
        //[Authorize("delete:article")] Disabled authentication for this test
        public IActionResult DeleteArticle(string articleId)
        {
            string deletedId;
            try
            {
                deletedId = _dataController.DeleteArticle(articleId);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    e.Message
                });
            }
            return Json(new
            {
                Message = $"Article ({deletedId}) successfully deleted"
            });
        }

        [HttpPost]
        [Route("author")]
        //[Authorize("add:author")] Disabled authentication for this test
        public IActionResult AddAuthor([FromBody]Author author)
        {
            string createdId;
            try
            {
                createdId = _dataController.AddAuthor(author);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    e.Message
                });
            }
            return Json(new
            {
                Message = $"Author ({createdId}) successfully registered"
            });
        }

        /// <summary>
        /// This is a helper action. It allows you to easily view all the claims of the token
        /// </summary>
        /// <returns></returns>
        [HttpGet("claims")]
        public IActionResult Claims()
        {
            return Json(User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                }));
        }
    }
}
