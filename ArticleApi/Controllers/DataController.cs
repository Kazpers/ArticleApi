using System;
using System.Collections.Generic;
using System.Linq;
using ArticleApi.Data;
using ArticleApi.Model;

namespace ArticleApi.Controllers
{
    // Here I would use a solution like CosmosDB on Azure or DynamoDB on Amazon for an actual application.
    // But for testing we stub it out and "cheat" with a static class providing data. But by using an interface we can easily switch in some more advanced storage solutions later.
    public class DataController : IDataController
    {
        public List<IArticleBase> GetAllArticles()
        {
            return DataStorage.Articles.Cast<IArticleBase>().ToList();
        }

        /// <inheritdoc />
        public List<IArticle> GetArticlesByAuthor(string authorId)
        {
            var author = CheckAuthor(authorId);

            return DataStorage.Articles.FindAll(x => x.Author.Id == author.Id);
        }


        /// <inheritdoc />
        public IArticle GetArticle(string articleId)
        {
            return CheckArticle(articleId);
        }

        public List<IAuthor> GetAllAuthors()
        {
            return DataStorage.Authors;
        }

        public string AddArticle(IArticle article, string authorId)
        {
            // In a real DB using scenario this might be handled by the DB if it supports auto-increment/identity columns. This should ensure no collision for our test
            article.Id = Guid.NewGuid().ToString();

            if (string.IsNullOrWhiteSpace(article.Topic))
            {
                throw new Exception("Topic must be set for article");
            }
            
            if (string.IsNullOrWhiteSpace(article.ArticleBody))
            {
                throw new Exception("Body must be set for article");
            }

            if (string.IsNullOrWhiteSpace(authorId))
            {
                throw new Exception("Author must be set for article");
            }

            article.Author = CheckAuthor(authorId);
            DataStorage.Articles.Add(article);

            return article.Id;
        }

        /// <inheritdoc />
        public string AddAuthor(IAuthor author)
        {
            // In a real DB using scenario this might be handled by the DB if it supports auto-increment/identity columns. This should ensure no collision for our test
            author.Id = Guid.NewGuid().ToString();

            if (string.IsNullOrWhiteSpace(author.Name))
            {
                throw new Exception("Name must be set for author");
            }

            if (string.IsNullOrWhiteSpace(author.Email))
            {
                throw new Exception("Email must be set for author");
            }
            // We don't require a phone registration for this service. Email contact should be sufficient.

            DataStorage.Authors.Add(author);

            return author.Id;
        }

        /// <inheritdoc />
        public string DeleteArticle(string articleId)
        {
            if (DataStorage.Articles.Any(x => x.Id == articleId))
            {
                DataStorage.Articles.RemoveAll(x => x.Id == articleId);

                return articleId;
            }

            return null;
        }

        private IAuthor CheckAuthor(string authorId)
        {
            var author = DataStorage.Authors.FirstOrDefault(x => x.Id == authorId);

            if (author == null)
            {
                throw new Exception("No such author exists");
            }

            return author;
        }

        private IArticle CheckArticle(string articleId)
        {
            var article = DataStorage.Articles.FirstOrDefault(x => x.Id == articleId);

            if (article == null)
            {
                throw new Exception("No such article exists");
            }

            return article;
        }
    }
}