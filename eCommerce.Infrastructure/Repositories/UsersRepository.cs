using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
  private readonly DapperDbContext _dbContext;

  public UsersRepository(DapperDbContext dbContext)
  {
    _dbContext = dbContext;
  }

    //public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    //{
    //  //Generate a new unique user ID for the user
    //  user.UserID = Guid.NewGuid();

    //  // SQL Query to insert user data into the "Users" table.
    //  string query = "INSERT INTO public.\"users\"(\"email\", \"personname\", \"gender\", \"password\") VALUES(@Email, @PersonName, @Gender, @Password)";
    //  int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

    //  if (rowCountAffected > 0 )
    //  {
    //    return user;
    //  }
    //  else
    //  {
    //    return null;
    //  }
    //}
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        
        const string query = "SELECT insert_user(@Email, @PersonName, @Gender, @Password)";

        var parameters = new
        {
            Email = user.Email,
            PersonName = user.PersonName,
            Gender = user.Gender,
            Password = user.Password
        };

        Guid? newUserId = await _dbContext.DbConnection.ExecuteScalarAsync<Guid?>(query, parameters);

        if (newUserId != null)
        {
            user.UserID = newUserId.Value;
            return user;
        }

        return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
  {
    //SQL query to select a user by Email and Password
    string query = "SELECT * FROM public.\"users\" WHERE \"email\"=@Email AND \"password\"=@Password";
    var parameters = new { Email = email, Password = password };

    ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

    return user;
  }
    public async Task<ApplicationUser?> GetUserByEmail(string? email)
    {
        //SQL query to select a user by Email and Password
        string query = "SELECT * FROM public.\"users\" WHERE \"email\"=@Email";
        var parameters = new { Email = email};

        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;
    }
}

