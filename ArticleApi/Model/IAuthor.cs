namespace ArticleApi.Model
{
    // Todo: This class could use some far better advanced objects for eg. Address, Country, Phone and Email
    // That would allow much better validation and data quality
    public interface IAuthor
    {
        /// <summary>
        /// Id of author
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Full name of author
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Phone of author
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// Email of author
        /// </summary>
        string Email { get; set; }
    }
}