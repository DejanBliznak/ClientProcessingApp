using Data.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace ClientProcessingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ApiClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("getallclients")]      
        public IActionResult GetAllClients()
        {
            var clients = _clientService.GetClients().Result;
            return Ok(clients);
        }

        [HttpPut("updateclient/{id}")]
        public IActionResult UpdateClient(int id, UpdateClientModel updatedClient)
        {
           var client = _clientService.UpdateClient(id , updatedClient).Result;

            return Ok(client);
        }
    }
}
