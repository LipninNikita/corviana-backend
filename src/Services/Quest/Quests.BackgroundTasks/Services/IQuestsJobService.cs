using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest.BackgroundTasks.Services
{
    public interface IQuestsJobService
    {
        public Task<bool> AddJob(Guid QuestId, DateTime dtEnd);
    }
}
