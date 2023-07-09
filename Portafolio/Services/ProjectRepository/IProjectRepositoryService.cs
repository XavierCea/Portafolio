using Portafolio.Models;

namespace Portafolio.Services.ProjectRepository
{
    public interface IProjectRepositoryService
    {
        List<ProjectDTO> ObtainProjects();
    }
}
