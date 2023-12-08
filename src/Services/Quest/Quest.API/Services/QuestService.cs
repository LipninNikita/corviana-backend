using Quest.API.Data;
using Quest.API.DTO;
using System.Data.Entity;

namespace Quest.API.Services
{
    public class QuestService : IQuestService
    {
        private readonly AppDbContext _dbContext;

        public QuestService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Add(AddQuest input)
        {
            Data.Models.Quest model = input;
            await _dbContext.Quests.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model.Id;
        }

        public async Task<QuestCard> GetById(Guid id)
        {
            var result = await _dbContext.Quests.SingleOrDefaultAsync(x => x.Id == id);

            return result;

        }

        public async Task<IEnumerable<QuestCard>> GetByUserId(string userId)
        {
            var result = await _dbContext.Quests.Where(x => x.IdUser == userId).ToListAsync();

            return result.Select(x => (QuestCard)x);
        }
    }
}
