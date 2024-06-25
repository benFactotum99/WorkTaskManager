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
    public class WorkTasksService
    {
        private WorkTasksRepository workTasksRepository;

        public WorkTasksService(WorkTasksRepository workTasksRepository)
        {
            this.workTasksRepository = workTasksRepository;
        }

        public async Task<List<WorkTask>> GetAllAsync()
        {
            return await workTasksRepository.GetAllAsync();
        }

        public async Task<List<WorkTask>> GetAsync(Expression<Func<WorkTask, bool>> predicate)
        {
            return await workTasksRepository.GetAsync(predicate);
        }

        public async Task<WorkTask?> GetByIdAsync(int id)
        {
            return await workTasksRepository.GetByIdAsync(id);
        }

        public async Task<WorkTask> Create(WorkTask workTask)
        {
            await workTasksRepository.AddAsync(workTask);
            await workTasksRepository.SaveAsync();
            return workTask;
        }

        public async Task<WorkTask> Update(WorkTask workTask)
        {
            workTasksRepository.Update(workTask);
            await workTasksRepository.SaveAsync();
            return workTask;
        }

        public async Task Delete(int id)
        {
            await workTasksRepository.DeleteAsync(p => p.Id == id);
            await workTasksRepository.SaveAsync();
        }
    }
}
