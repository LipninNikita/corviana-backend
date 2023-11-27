using Grpc.Core;
using Services.Grpc.Interactions;

namespace Interaction.API.Services
{
    public class GrpcInteractionService : GrpcInteractionsService.GrpcInteractionsServiceBase
    {
        private readonly ILikeService _likeService;
        private readonly IViewService _viewService;

        public GrpcInteractionService(ILikeService likeService, IViewService viewService)
        {
            _likeService = likeService;
            _viewService = viewService;
        }

        public override async Task<GetPostInteractionsResponse> GetInteractions(GetPostInteractionsRequest request, ServerCallContext context)
        {
            var resultViews = await _viewService.GetViewsAmount(request.PostId);
            var resultLikes = await _likeService.GetLikesAmount(request.PostId);
            return new GetPostInteractionsResponse() { LikesAmount = resultLikes, ViewsAmount = resultViews };
        }
    }
}