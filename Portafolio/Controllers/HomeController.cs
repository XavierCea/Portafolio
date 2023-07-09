using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Services.Mail;
using Portafolio.Services.Person;
using Portafolio.Services.ProjectRepository;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectRepositoryService _projectRepository;
        private readonly IPersonService _personService;
        private readonly IMailService _mailService;

        public HomeController(ILogger<HomeController> logger, IProjectRepositoryService projectRepository, IPersonService personService, IMailService mailService)
        {
            _logger = logger;
            _projectRepository = projectRepository;
            _personService = personService;
            _mailService = mailService;

        }

        public IActionResult Index()
        {
            var projects = _projectRepository.ObtainProjects().Take(3).ToList();
            var person = _personService.GetPerson();
            var model = new HomeIndexViewModel() { Projects = projects , Person = person};

            return View("Index",model);
        }

        public IActionResult Technologies()
        {
            return View();
        } 
        
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactDTO contact)
        {
            await _mailService.SendEmail(contact);
            return RedirectToAction("ThanksToContact");
        }

        public IActionResult ThanksToContact()
        {
            return View();
        }

        public IActionResult Projects()
        {
            var projects = _projectRepository.ObtainProjects().ToList();

            return View("Projects", projects);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}