using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Services;

public class PersonService : BaseService<Person>, IPersonService
{
    public PersonService(
        IPersonRepository personRepository
        ) : base(personRepository)
    {
    }
}