using GymService.Model;
using GymService.UOW.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IGymUOW _uow;
        public ClientController(IGymUOW gymUOW)
        {
            _uow = gymUOW;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                var results = await _uow.ClientRepository.GetAllAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] Client client)
        {
            try
            {
                client.IsActive = true;
                client.CreatedOn = DateTime.Now;

                await _uow.ClientRepository.AddAsync(client);

                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}