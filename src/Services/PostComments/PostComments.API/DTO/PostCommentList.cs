using PostComments.API.Data.Models;

namespace PostComments.API.DTO
{
    public class PostCommentList
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public static implicit operator PostCommentList(PostComment input)
        {
            var output = new PostCommentList();
            output.Id = input.Id;
            output.UserId = input.UserId;
            output.PostId = input.PostId;
            output.Content = input.Content;
            output.DateTimeCreated = input.DateTimeCreated;

            return output;
        }
    }
}
