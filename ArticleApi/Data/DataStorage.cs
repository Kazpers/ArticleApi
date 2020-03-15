using System.Collections.Generic;
using ArticleApi.Model;

namespace ArticleApi.Data
{
    // This entire class is for "convenience". A quick and simple way to get some data in to test the service at each startup.
    // Not a lot of thought has gone into things like performance since this would be deprecated in any real use scenario by a DB.
    public static class DataStorage
    {
        public static List<IAuthor> Authors { get; } = new List<IAuthor>();
        public static List<IArticle> Articles { get; } = new List<IArticle>();

        public static void Populate()
        {
            var author1 = new Author("P. S. Madison", "pm@supermagasinet.dk");
            author1.Id = "ca93fc3b-195c-4293-ac5b-8b49e2c1684c";
            var author2 = new Author("King Paul Mader", "kpm@supermagasinet.dk");
            var author3 = new Author("Pouqu S. Madsen", "psm@supermagasinet.dk");

            Authors.Add(author1);
            Authors.Add(author2);
            Authors.Add(author3);

            var article1 = new Article(author1, "Stop med at trykke på knapper!", "Lorem  ipsum  dolor  sit  amet,  consectetur  adipiscing  elit.  Fusce  pretium,  nisi  ut  gravida vehicula,  turpis  massa  dignissim  ipsum,  quis  commodo  purus  urna  sit  amet  nunc.  Nunc fermentum, orci sed auctor consequat, est neque ultricies metus, in posuere leo dui porta mi.", 2020);
            article1.Id = "c4c2177b-8465-40dc-a8b8-a706f7d99f35";
            var article2 = new Article(author3, "Tryk på flere knapper!", "Pellentesque porta orci at neque porttitor ac varius magna scelerisque. Nam sed est enim, vitae sollicitudin quam. Proin justo turpis, posuere vel consequat quis, pulvinar sed libero.", 2020);
            
            Articles.Add(article1);
            Articles.Add(article2);
        }
    }
}