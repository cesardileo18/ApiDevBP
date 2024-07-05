using ApiDevBP.Contract.DataBaseConection;
using ApiDevBP.Contract.DTO;
using ApiDevBP.Core.Domain;
using ApiDevBP.Core.Repository;
using ApiDevBP.Repository.Entities;
using Microsoft.Extensions.Options;
using SQLite;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace ApiDevBP.Repository.Repository.Implementation
{
    public class UserRepositoryImplementation : IUserRepository
    {
        //private readonly ILogger _logger;
        private readonly DataBaseConection _dataBaseConection;
        private readonly SQLiteConnection _db;
        //public UserRepositoryImplementation(ILogger logger, IOptions<DataBaseConection> dataBaseConection)
        public UserRepositoryImplementation(IOptions<DataBaseConection> dataBaseConection)
        {
            //_logger = logger;
            _dataBaseConection = dataBaseConection.Value;
            try
            {
                string sourcePath = _dataBaseConection.ConnectionString;
                _db = new SQLiteConnection(sourcePath);
                _db.CreateTable<UserDomain>();
            }
            catch (Exception ex)
            {
                //_logger.Error($"Error{ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        public Task<List<UserDomain>> GetUsersAsync()
        {
            try
            {
                var users = _db.Table<UserDomain>().ToList();
                //_logger.Info("Get de Datos Sql");
                return Task.FromResult(users);
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
                var userDomain = new UserDomain()
                {
                    Name = user.Name,
                    Lastname = user.Lastname
                };

                // Insertar el usuario en la base de datos
                _db.Insert(userDomain);

                // Retornar el objeto UserDomain con el Id asignado
                UserDomain userDomain5 = await Task.FromResult(userDomain);
                //_logger.Info("Post de Datos Sql");
                return userDomain5;
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
                var user = _db.Find<UserDomain>(id);
                if (user == null)
                {
                    return await Task.FromResult<UserDomain?>(null); // Usuario no encontrado
                }

                // Actualizar las propiedades del usuario
                user.Name = userDto.Name ?? user.Name;
                user.Lastname = userDto.Lastname ?? user.Lastname;

                _db.Update(user);
                //_logger.Info("Put de Datos Sql");
                return await Task.FromResult(user); // Retorna el usuario actualizado
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
                var user = _db.Find<UserDomain>(id);
                if (user == null)
                {
                    return await Task.FromResult<UserDomain?>(null); // Usuario no encontrado
                }

                _db.Delete(user);
                //_logger.Info("Delete de Datos Sql");
                return await Task.FromResult(user); // Retorna el usuario eliminado
            }
            catch (Exception ex)
            {
                //_logger.Error($"Error{ex.Message}");
                throw new Exception(ex.Message);
            }
         
        }
    }
}
