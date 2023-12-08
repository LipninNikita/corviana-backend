using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using Theme.API.Data;
using Theme.API.DTO;

namespace Theme.API.Services
{
    public class ThemeService : IThemeService
    {
        private readonly AppDbContext _dbContext;

        public ThemeService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(AddTheme input)
        {
            Data.Models.Theme model = input;
            await _dbContext.Themes.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model.Id;
        }

        public async Task<ThemeOutput> GetById(int id)
        {
            var result = await _dbContext.Themes.SingleOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<IEnumerable<ThemeOutput>> GetThemes()
        {
            var result = await _dbContext.Themes.ToListAsync();

            return result.Select(x => (ThemeOutput)x);
        }

        public async Task Remove(int id)
        {
            var result = await _dbContext.Themes.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<int> Update(UpdateTheme input)
        {
            var result = _dbContext.Themes.Update(input);
            await _dbContext.SaveChangesAsync();

            return input.Id;
        }
    }
}
