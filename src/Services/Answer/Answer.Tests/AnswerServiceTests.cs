using Moq.EntityFrameworkCore;
using Answer.API.Data;
using Answer.API.Data.Models;
using Answer.API.DTO;
using Answer.API.Services;
using AutoFixture;
using Moq;
using Answer.API.Events.Models;
using Services.Common.Middlewares.Exceptions;

namespace Answer.Tests
{
    public class AnswerServiceTests
    {
        private readonly Mock<AnswerService> _answerServiceMock;
        public AnswerServiceTests()
        {
            var fixture = new Fixture();
            var dataFixture = fixture.Build<API.Data.Models.Answer>().With(x => x.QuestionId, 1).CreateMany(5);

            var dbContextMock = new Mock<AppDbContext>();
            dbContextMock.Setup(x => x.Answers).ReturnsDbSet(dataFixture);

            _answerServiceMock = new Mock<AnswerService>(dbContextMock.Object);
        }

        [Fact]
        public async void AnswerService_AddNewAnswer_ValidInput()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var sut = fixture.Create<AddAnswer>();

            var data = await _answerServiceMock.Object.Add(sut);
            Assert.IsType<Guid>(data);
        }

        [Fact]
        public async void AnswerService_GetByQuestionId_ValidInput()
        {
            var data = await _answerServiceMock.Object.GetByQuestionId(1);

            Assert.NotNull(data);
        }

        [Fact]
        public async void AnswerService_GetByQuestionId_InvalidInput()
        {
            await Assert.ThrowsAsync<ContentNotFoundException>(async () => await _answerServiceMock.Object.GetByQuestionId(10000));
        }
    }
}