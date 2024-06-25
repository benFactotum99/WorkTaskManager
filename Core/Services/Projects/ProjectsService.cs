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
    public class ProjectsService
    {
        private ProjectsRepository projectsRepository;

        public ProjectsService(ProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await projectsRepository.GetAllAsync();
        }

        public async Task<List<Project>> GetAsync(Expression<Func<Project, bool>> predicate)
        {
            return await projectsRepository.GetAsync(predicate);
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await projectsRepository.GetByIdAsync(id);
        }

        public async Task<Project> Create(Project project)
        {
            await projectsRepository.AddAsync(project);
            await projectsRepository.SaveAsync();
            return project;
        }

        public async Task<Project> Update(Project project)
        {
            projectsRepository.Update(project);
            await projectsRepository.SaveAsync();
            return project;
        }

        public async Task Delete(int id)
        {
            await projectsRepository.DeleteAsync(p => p.Id == id);
            await projectsRepository.SaveAsync();
        }
    }
}
