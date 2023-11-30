namespace Post.API.DTO
{
    public class PostList
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }
        public string UserId { get; set; }

        public static implicit operator PostList(Data.Models.Post input)
        {
            var result = new PostList();
            result.Id = input.Id;
            result.DateTimeCreated = input.DateTimeCreated;
            result.DateTimeUpdated = input.DateTimeUpdated;
            result.UserId = input.UserId;

            return result;
        }
    }
}
