using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IEntityRepositoryBase<int, User> userRepository;
    private readonly IEntityRepositoryBase<int, Role> roleRepository;
    public LoginController(
        IEntityRepositoryBase<int, User> userRepository,
        IEntityRepositoryBase<int, Role> roleRepository)
    {
        this.userRepository = userRepository;
        this.roleRepository = roleRepository;
    }

    [HttpPost]
    public async Task<LoginResponse> Login(LoginModel loginModel)
    {
        var clients = (await userRepository.GetAll()).AsQueryable();

        foreach (var client in clients)
        {
            if (loginModel.Username == client.Username && loginModel.Password == client.Password)
            {
                var roles = (await roleRepository.GetAll()).AsQueryable();
                return new LoginResponse
                {
                    UserName = client.Username,
                    Password = client.Password,
                    Role = roles.FirstOrDefault(x => x.Id == client.RoleId).RoleName,
                };
            }
        }
        return new LoginResponse
        {
            UserName = default,
            Password = default,
            Role = default,
        };
    }
}