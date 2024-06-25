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
    public class WorkTaskTypesService
    {
        private WorkTaskTypesRepository workTaskTypesRepository;

        public WorkTaskTypesService(WorkTaskTypesRepository workTaskTypesRepository)
        {
            this.workTaskTypesRepository = workTaskTypesRepository;
        }

        public async Task<List<WorkTaskType>> GetAllAsync()
        {
            return await workTaskTypesRepository.GetAllAsync();
        }

        public async Task<List<WorkTaskType>> GetAsync(Expression<Func<WorkTaskType, bool>> predicate)
        {
            return await workTaskTypesRepository.GetAsync(predicate);
        }

        public async Task<WorkTaskType?> GetByIdAsync(int id)
        {
            return await workTaskTypesRepository.GetByIdAsync(id);
        }

        public async Task<WorkTaskType> Create(WorkTaskType workTaskType)
        {
            await workTaskTypesRepository.AddAsync(workTaskType);
            await workTaskTypesRepository.SaveAsync();
            return workTaskType;
        }

        public async Task<WorkTaskType> Update(WorkTaskType workTaskType)
        {
            workTaskTypesRepository.Update(workTaskType);
            await workTaskTypesRepository.SaveAsync();
            return workTaskType;
        }

        public async Task Delete(int id)
        {
            await workTaskTypesRepository.DeleteAsync(p => p.Id == id);
            await workTaskTypesRepository.SaveAsync();
        }
    }
}
