using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ApiDevBP.Core.Service;
using ApiDevBP.Core.Repository;
using ApiDevBP.Repository.Entities;
using ApiDevBP.Contract.DTO;
using ApiDevBP.Core.Domain;

namespace ApiDevBP.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        //private readonly ILogger? _logger;
        private readonly IMapper? _mapper;
        private readonly IUserService? _userService;


        //public UsersController(ILogger? logger, IMapper? mapper)
        public UsersController(IMapper? mapper, IUserService userService)
        {
            //_logger = logger;
            _mapper = mapper;
            _userService = userService;  
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                //_logger.LogInformation("Get de Datos");
                var users = await _userService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Error{ex.Message}");
                return BadRequest(ex.Message);
            }
   
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(UserDTO user)
        {
            try
            {
                var userResult = await _userService.SaveUser(user);
                //_logger.LogInformation("Datos Insertados correctamente");
                return Ok(userResult);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Error{ex.Message}");
                return BadRequest(ex.Message);
            }
        
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDto)
        {
            try
            {
                var user = await _userService.UpdateUser(id, userDto);
                if (user == null)
                {
                    return NotFound(); // 404 Not Found
                }
                //_logger.LogInformation("Datos Actualizados correctamente");

                return Ok(user); // 200 OK con el objeto actualizado
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Error{ex.Message}");
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userService.DeleteUser(id);
                if (user == null)
                {
                    return NotFound(); // 404 Not Found
                }
                //_logger.LogInformation("Datos Eliminados correctamente");

                return Ok(user);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Error{ex.Message}");
                //throw new Exception(ex.Message);
                return BadRequest(ex.Message);  
            }
           
        }
    }
}
