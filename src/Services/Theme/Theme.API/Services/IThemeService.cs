using Theme.API.Data.Models;
using Theme.API.DTO;

namespace Theme.API.Services
{
    public interface IThemeService
    {
        public Task<IEnumerable<ThemeOutput>> GetThemes();
        public Task<ThemeOutput> GetByIt(int id);
        public Task<int> Update(UpdateTheme input);
        public Task<int> Add(AddTheme input);
        public Task Remove(int id);
    }
}
