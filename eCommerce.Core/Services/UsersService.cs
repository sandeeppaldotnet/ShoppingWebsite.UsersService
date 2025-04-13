using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
  private readonly IUsersRepository _usersRepository;
  private readonly IMapper _mapper;
  private readonly JwtTokenService _jwtTokenService;

  public UsersService(IUsersRepository usersRepository, IMapper mapper,JwtTokenService jwtTokenService)
  {
    _usersRepository = usersRepository;
    _mapper = mapper;
        _jwtTokenService = jwtTokenService;
  }


  public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
  {
    ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

    if (user == null)
    {
      return null;
    }

    //return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Success: true);
    return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = _jwtTokenService.GenerateToken(user.UserID,user?.Email) };
  }


  public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
  {
    //Create a new ApplicationUser object from RegisterRequest
    ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);
    ApplicationUser isExistUser = await _usersRepository.GetUserByEmail(registerRequest.Email);
        if (isExistUser != null)
        {
            return new AuthenticationResponse() { Success = false, Message = "User already exists" };
        }
            ApplicationUser? registeredUser = await _usersRepository.AddUser(user);
    if (registeredUser == null)
    {
      return null;
    }

    //Return success response
    //return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName, registeredUser.Gender, "token", Success: true);
    return _mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = _jwtTokenService.GenerateToken(user.UserID, user?.Email) };
  }
}
