using System;

namespace KennelUnion.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}