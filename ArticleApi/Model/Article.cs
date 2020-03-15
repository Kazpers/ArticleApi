using System;
using System.Collections.Generic;

namespace ArticleApi.Model
{
    public class Article : ArticleBase, IArticle
    {
        public IAuthor Author { get; set; }
        public int Year { get; set; }
        public string ArticleBody { get; set; }

        /// <summary>
        /// Only intended for serialization
        /// </summary>
        public Article()
        {
            // For serialization
        }


        /// <summary>
        /// Use this to create a new instance of the class
        /// </summary>
        /// <param name="author"></param>
        /// <param name="topic"></param>
        /// <param name="body"></param>
        /// <param name="year"></param>
        public Article(IAuthor author, string topic, string body, int year)
        {
            Id = Guid.NewGuid().ToString();

            Author = author;
            Topic = topic;
            ArticleBody = body;
            Year = year;
        }

        
    }
}