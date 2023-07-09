using Portafolio.Models;

namespace Portafolio.Services.ProjectRepository
{
    public class ProjectRepositoryService : IProjectRepositoryService
    {
        public List<ProjectDTO> ObtainProjects()
        {
            return new List<ProjectDTO>() {
                new ProjectDTO()
                {
                    Title = "GifApp",
                    Description = "Aplicación en React para la busqueda de gifs online.",
                    Link = "https://gifappcegon.netlify.app/",
                    ImageURL = "/Resources/images/GifAppView.gif"
                },
                new ProjectDTO()
                {
                    Title = "Virtual Assistant",
                    Description = "Asistente virtual con voz creado con Python.",
                    Link = "https://github.com/XavierCea/VirtualAssistant",
                    ImageURL = "/Resources/images/VirtualAssistantView.png"

                },
                new ProjectDTO()
                {
                    Title = "Protafolio",
                    Description = "Aplicación web para mostrar mi infroamción profesional.",
                    Link = "https://github.com/XavierCea/VirtualAssistant",
                    ImageURL = "/Resources/images/PortafolioView.gif"

                }
            };
        }

    }
}
