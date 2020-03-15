namespace ArticleApi.Model
{
    public interface IArticleBase
    {
        /// <summary>
        /// Id of article
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Topic of the article
        /// </summary>
        string Topic { get; set; }
    }
}