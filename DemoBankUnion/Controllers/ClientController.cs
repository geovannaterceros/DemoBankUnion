using AutoMapper;
using DemoBank.BL.Interfaces;
using DemoBank.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoBankUnion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IServices<ClientDto> _ClientsService;
        private readonly IMapper _mapper;

        public ClientController(IServices<ClientDto> ClientsService, IMapper mapper)
        {
            _ClientsService = ClientsService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            ClientDto ClientDto = await _ClientsService.GetAsync(id);
            if (ClientDto is not null)
            {
                return Ok(ClientDto);
            }

            return NotFound();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<ClientDto> ClientDtos = await _ClientsService.GetAsync();
            if (ClientDtos is not null)
            {
                return Ok(ClientDtos);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ClientCreateDto ClientCreateDto)
        {

            ClientDto clientDto = _mapper.Map<ClientDto>(ClientCreateDto);
            ClientDto ClientDtoCreated = await _ClientsService.CreateAsync(clientDto);

            if (ClientDtoCreated is not null)
            {
                return Created(nameof(CreateAsync), ClientDtoCreated);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ClientDto clientDto)
        {

            ClientDto ClientDtoUpdated = await _ClientsService.UpdateAsync(id, clientDto);

            if (ClientDtoUpdated is not null)
            {
                return Ok(ClientDtoUpdated);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {

            ClientDto clientDtoDelete = await _ClientsService.DeleteAsync(id);

            if (clientDtoDelete is not null)
            {
                return Ok(clientDtoDelete);
            }
            return NotFound();
        }

    }
}
