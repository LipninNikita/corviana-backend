using Grpc.Core;
using Question.API.DTO;
using Questions.API.Grpc.Services;

namespace Question.API.Services
{
    public class QuestionsGrpc : QuestionsGrpcService.QuestionsGrpcServiceBase
    {
        private readonly IQuestionService _questionService;
        public QuestionsGrpc(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public override async Task<AddQuestionResponse> AddQuestion(AddQuestionRequest request, ServerCallContext context)
        {
            var result = await _questionService.Add(
                new AddQuestion() 
                { 
                    Title = request.Title,
                    Content = request.Content, 
                    Level = (Data.Models.QuestionLvlEnum)request.Lvl, 
                    Type = (Data.Models.QuestionTypeEnum)request.Type, 
                    IsFree =  request.IsFree ,
                    Hint = request.Hint
                });

            var response = new AddQuestionResponse();
            response.Id = result;
            return response;
        }
    }
}
