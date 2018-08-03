namespace KennelUnion.Data.Entity
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Author Author { get; set; }
    }
}