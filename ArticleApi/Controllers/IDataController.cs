using System.Collections.Generic;
using ArticleApi.Model;

namespace ArticleApi.Controllers
{
    // Todo: Filters and search
    public interface IDataController
    {
        /// <summary>
        /// Get all articles
        /// </summary>
        List<IArticleBase> GetAllArticles();

        /// <summary>
        /// Get all articles by author with a specific id
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        List<IArticle> GetArticlesByAuthor(string authorId);

        /// <summary>
        /// Get article with specific id
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        IArticle GetArticle(string articleId);

        /// <summary>
        /// Get all authors
        /// </summary>
        List<IAuthor> GetAllAuthors();

        /// <summary>
        /// Add an article
        /// </summary>
        /// <param name="article"></param>
        /// <param name="authorId"></param>
        /// <returns></returns>
        string AddArticle(IArticle article, string authorId);

        /// <summary>
        /// Add an author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        string AddAuthor(IAuthor author);

        /// <summary>
        /// Delete a article
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        string DeleteArticle(string articleId);
    }
}