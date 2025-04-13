using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

/// <summary>
/// Contract to be implemented by UsersRepository that contains data access logic of Users data store
/// </summary>
public interface IUsersRepository
{
  /// <summary>
  /// Method to add a user to the data store and return the added user
  /// </summary>
  /// <param name="user"></param>
  /// <returns></returns>
  Task<ApplicationUser?> AddUser(ApplicationUser user);


  /// <summary>
  /// Method to retrieve existing user by their email and password
  /// </summary>
  /// <param name="email"></param>
  /// <param name="password"></param>
  /// <returns></returns>
  Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    /// <summary>
    /// Method to retrieve existing user by their email 
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmail(string? email);
}
