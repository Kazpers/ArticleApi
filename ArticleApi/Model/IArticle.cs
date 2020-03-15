namespace ArticleApi.Model
{
    public interface IArticle : IArticleBase
    {
        /// <summary>
        /// Author of the article
        /// </summary>
        IAuthor Author { get; set; }

        /// <summary>
        /// Year of the article
        /// </summary>
        int Year { get; set; }

        /// <summary>
        /// Body of the article
        /// </summary>
        string ArticleBody { get; set; }
    }
}