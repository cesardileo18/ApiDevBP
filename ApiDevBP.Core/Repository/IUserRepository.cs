using ApiDevBP.Contract.DTO;
using ApiDevBP.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevBP.Core.Repository
{
    public interface IUserRepository
    {
        Task<List<UserDomain>> GetUsersAsync();
        Task<UserDomain> SaveUser(UserDTO user);
        Task<UserDomain?> DeleteUser(int id);
        Task<UserDomain?> UpdateUser(int id, UserDTO userDto);
    }
}
