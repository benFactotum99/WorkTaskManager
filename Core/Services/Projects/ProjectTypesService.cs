using Infrastructure.Persistence.Entity;
using Infrastructure.Persistence.Repository.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Projects
{
    public class ProjectTypesService
    {
        private ProjectTypesRepository projectTypesRepository;

        public ProjectTypesService(ProjectTypesRepository projectTypesRepository)
        {
            this.projectTypesRepository = projectTypesRepository;
        }

        public async Task<List<ProjectType>> GetAllAsync()
        {
            return await projectTypesRepository.GetAllAsync();
        }

        public async Task<List<ProjectType>> GetAsync(Expression<Func<ProjectType, bool>> predicate)
        {
            return await projectTypesRepository.GetAsync(predicate);
        }

        public async Task<ProjectType?> GetByIdAsync(int id)
        {
            return await projectTypesRepository.GetByIdAsync(id);
        }

        public async Task<ProjectType> Create(ProjectType projectType)
        {
            await projectTypesRepository.AddAsync(projectType);
            await projectTypesRepository.SaveAsync();
            return projectType;
        }

        public async Task<ProjectType> Update(ProjectType projectType)
        {
            projectTypesRepository.Update(projectType);
            await projectTypesRepository.SaveAsync();
            return projectType;
        }

        public async Task Delete(int id)
        {
            await projectTypesRepository.DeleteAsync(p => p.Id == id);
            await projectTypesRepository.SaveAsync();
        }
    }
}
