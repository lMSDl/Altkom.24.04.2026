using Models;

namespace WebApp.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = [];
    private int _nextId = 1;

    public IReadOnlyCollection<User> GetAll() => _users;

    public User? GetById(int id) => _users.FirstOrDefault(user => user.Id == id);

    public User Create(UserDto dto)
    {
        var user = new User
        {
            Id = _nextId++,
            Login = dto.Login,
            Password = dto.Password
        };

        _users.Add(user);
        return user;
    }

    public User? Update(int id, UserDto dto)
    {
        var user = GetById(id);
        if (user is null)
        {
            return null;
        }

        user.Login = dto.Login;
        user.Password = dto.Password;
        return user;
    }

    public bool Delete(int id)
    {
        var user = GetById(id);
        if (user is null)
        {
            return false;
        }

        _users.Remove(user);
        return true;
    }
}
