using ApiDevBP.Contract.DTO;
using ApiDevBP.Core.Domain;
using ApiDevBP.Core.Repository;
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiDevBP.Core.Service.Implementation
{
    public class UserService : IUserService
    {
        //private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;
        //public UserService(ILogger<UserService> logger, IUserRepository userRepository) {
        public UserService(IUserRepository userRepository)
        {
            //_logger = logger;
            _userRepository = userRepository;   
        }

        public async Task<List<UserDomain>> GetUsersAsync()
        {
            try
            {
                return await _userRepository.GetUsersAsync();
            }
            catch (Exception ex) 
            {
                //_logger.Error($"Error{ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDomain> SaveUser(UserDTO user)
        {
            try
            {
                return await _userRepository.SaveUser(user);
            }
            catch (Exception ex)
            {
                //_logger.Error($"Error{ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        public async Task<UserDomain?> UpdateUser(int id, UserDTO userDto)
        {
            try
            {
                return await _userRepository.UpdateUser(id, userDto);
            }
            catch (Exception ex)
            {
                //_logger.Error($"Error{ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        public async Task<UserDomain?> DeleteUser(int id)
        {
            try
            {
                return await _userRepository.DeleteUser(id);
            }
            catch (Exception ex)
            {
                //_logger.Error($"Error{ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
