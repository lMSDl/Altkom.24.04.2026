using Models;

namespace WebApp.Services;

public interface IUserService
{
    IReadOnlyCollection<User> GetAll();
    User? GetById(int id);
    User Create(UserDto dto);
    User? Update(int id, UserDto dto);
    bool Delete(int id);
}
