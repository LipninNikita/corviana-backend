using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest.BackgroundTasks.Services
{
    public interface IQuestsService
    {
        public Task<bool> AddQuest()
    }
}
