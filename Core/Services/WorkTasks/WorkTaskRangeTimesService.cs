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
    public class WorkTaskRangeTimesService
    {
        private WorkTaskRangeTimesRepository workTaskRangeTimesRepository;

        public WorkTaskRangeTimesService(WorkTaskRangeTimesRepository workTaskRangeTimesRepository)
        {
            this.workTaskRangeTimesRepository = workTaskRangeTimesRepository;
        }

        public async Task<List<WorkTaskRangeTime>> GetAllAsync()
        {
            return await workTaskRangeTimesRepository.GetAllAsync();
        }

        public async Task<List<WorkTaskRangeTime>> GetAsync(Expression<Func<WorkTaskRangeTime, bool>> predicate)
        {
            return await workTaskRangeTimesRepository.GetAsync(predicate);
        }

        public async Task<WorkTaskRangeTime?> GetByIdAsync(int id)
        {
            return await workTaskRangeTimesRepository.GetByIdAsync(id);
        }

        public async Task<WorkTaskRangeTime> Create(WorkTaskRangeTime workTaskRangeTime)
        {
            await workTaskRangeTimesRepository.AddAsync(workTaskRangeTime);
            await workTaskRangeTimesRepository.SaveAsync();
            return workTaskRangeTime;
        }

        public async Task<WorkTaskRangeTime> Update(WorkTaskRangeTime workTaskRangeTime)
        {
            workTaskRangeTimesRepository.Update(workTaskRangeTime);
            await workTaskRangeTimesRepository.SaveAsync();
            return workTaskRangeTime;
        }

        public async Task Delete(int id)
        {
            await workTaskRangeTimesRepository.DeleteAsync(p => p.Id == id);
            await workTaskRangeTimesRepository.SaveAsync();
        }
    }
}
