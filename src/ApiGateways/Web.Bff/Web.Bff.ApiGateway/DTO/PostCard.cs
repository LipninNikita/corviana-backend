namespace Web.Bff.ApiGateway.DTO
{
    public class PostCard
    {
        public IEnumerable<string> Images { get; set; }
        public Guid UserId { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public dynamic Comments { get; set; }
        public dynamic 
    }
}
