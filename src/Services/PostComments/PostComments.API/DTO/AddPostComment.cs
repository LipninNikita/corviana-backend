using PostComments.API.Data.Models;

namespace PostComments.API.DTO
{
    public class AddPostComment
    {
        public string PostId { get; set; }
        public string Content { get; set; }

        public static implicit operator PostComment(AddPostComment postComment)
        {
            var output = new PostComment();
            output.PostId = postComment.PostId;
            output.Content = postComment.Content;

            return output;
        }
    }
}
