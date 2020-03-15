using System;

namespace ArticleApi.Model
{
    public class Author : IAuthor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Only intended for serialization
        /// </summary>
        public Author()
        {
            // For serialization
        }

        /// <summary>
        /// Use this to create a new instance of the class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="phone">Optional</param>
        public Author(string name, string email, string phone = null)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}