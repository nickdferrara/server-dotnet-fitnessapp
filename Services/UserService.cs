using server_dotnet_fitnessapp.Exceptions;
using server_dotnet_fitnessapp.Models;
using server_dotnet_fitnessapp.Repositories.Interfaces;
using server_dotnet_fitnessapp.Services.Interfaces;

namespace server_dotnet_fitnessapp.Services;

public class UserService : BaseService<User>, IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(
        IUserRepository userRepository
        ) : base(userRepository)
    {
        _userRepository = userRepository;
    }

    private User? FindByEmail(string email) =>
        Get().FirstOrDefault(x => x.Email.Equals(email));

    public User Insert(User user)
    {
        var existingUser = FindByEmail(user.Email);
        if (existingUser is not null) 
            throw new EmailAlreadyExistsException("Email already exists. Try logging in.");
        return _userRepository.Insert(user);
    }

    public User Login(User user)
    {
        var existingUser = FindByEmail(user.Email);
        if (existingUser is null) 
            throw new EmailNotFoundException("No email found");
        
        if (!existingUser.Password.Equals(user.Password)) 
            throw new PasswordIncorrectException("Password is incorrect");
        
        return existingUser;
    }
}