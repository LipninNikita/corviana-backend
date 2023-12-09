using Grpc.Core;
using Questions.API.Grpc.Services;

namespace Web.Bff.ApiGateway.Services
{
    public class QuestionsGrpcServiceClient : QuestionsGrpcService.QuestionsGrpcServiceClient
    {
        public override AddQuestionResponse AddQuestion(AddQuestionRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            return base.AddQuestion(request, headers, deadline, cancellationToken);
        }

        public override AddQuestionResponse AddQuestion(AddQuestionRequest request, CallOptions options)
        {
            return base.AddQuestion(request, options);
        }

        public override AsyncUnaryCall<AddQuestionResponse> AddQuestionAsync(AddQuestionRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            return base.AddQuestionAsync(request, headers, deadline, cancellationToken);
        }

        public override AsyncUnaryCall<AddQuestionResponse> AddQuestionAsync(AddQuestionRequest request, CallOptions options)
        {
            return base.AddQuestionAsync(request, options);
        }
    }
}
