using AuthService.Model;
using AuthService.UOW.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata.Ecma335;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAuthUOW _uow;
        public AdminController(IAuthUOW authUOW)
        {
            _uow = authUOW;
        }

        [HttpGet("GetAllAdmin")]
        public async Task<IActionResult> GetAllAdminUsers()
        {
            try
            {
                return Ok(await _uow.AdminRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmins([FromBody] AdminUser input)
        {
            try
            {
                input.CreatedOn = DateTime.Now;

                await _uow.AdminRepository.AddAsync(input);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
