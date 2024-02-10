namespace DSLearn.Entities
{
    public class Reply
    {

        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Moment { get; set; }


        public int TopicId { get; set; }
        public Topic Topic { get; set; }    


        public IEnumerable<User> Likes { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }

    }
}
