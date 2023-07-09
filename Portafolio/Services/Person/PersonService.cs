using Portafolio.Models;

namespace Portafolio.Services.Person
{
    public class PersonService : IPersonService
    {
        public PersonDTO GetPerson()
        {
            var person = new PersonDTO()
            {
                Name = "Xavier",
                Surname = "Cea Gonzalez",
                Birthday = DateTime.Parse("19/09/1997")
            };
            return person;
        }
    }
}
