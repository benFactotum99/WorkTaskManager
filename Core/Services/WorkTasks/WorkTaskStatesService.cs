using Infrastructure.Persistence.Entity;
using Infrastructure.Persistence.Repository.WorkTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.WorkTasks
{
    public class WorkTaskStatesService
    {
        private WorkTaskStatesRepository workTaskStatesRepository;

        public WorkTaskStatesService(WorkTaskStatesRepository workTaskStatesRepository)
        {
            this.workTaskStatesRepository = workTaskStatesRepository;
        }

        public async Task<List<WorkTaskState>> GetAllAsync()
        {
            return await workTaskStatesRepository.GetAllAsync();
        }

        public async Task<List<WorkTaskState>> GetAsync(Expression<Func<WorkTaskState, bool>> predicate)
        {
            return await workTaskStatesRepository.GetAsync(predicate);
        }

        public async Task<WorkTaskState?> GetByIdAsync(int id)
        {
            return await workTaskStatesRepository.GetByIdAsync(id);
        }

        public async Task<WorkTaskState> Create(WorkTaskState workTaskState)
        {
            await workTaskStatesRepository.AddAsync(workTaskState);
            await workTaskStatesRepository.SaveAsync();
            return workTaskState;
        }

        public async Task<WorkTaskState> Update(WorkTaskState workTaskState)
        {
            workTaskStatesRepository.Update(workTaskState);
            await workTaskStatesRepository.SaveAsync();
            return workTaskState;
        }

        public async Task Delete(int id)
        {
            await workTaskStatesRepository.DeleteAsync(p => p.Id == id);
            await workTaskStatesRepository.SaveAsync();
        }
    }
}
