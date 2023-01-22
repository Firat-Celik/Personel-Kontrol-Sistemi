using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonelKontrol.Service.Interface;
using PersonelKontrol.Application.DTOs;
using PersonelKontrol.Domain.Entities.Concrates;
using PersonelKontrol.Presentation.Exceptions;
using PersonelKontrol.Presentation.Filters;
using PersonelKontrol.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonelKontrol.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMovementsController : ControllerBase
    {
        private readonly IEmployeeMovementsService _employeeMovementsService;
        private readonly IMapper _mapper;

        public EmployeeMovementsController(IEmployeeMovementsService employeeMovementsService, IMapper mapper)
        {
            _employeeMovementsService = employeeMovementsService;
            _mapper = mapper;
        }

        [HttpGet("GetEmployeeMovementsList")]
        [ExceptionFilter]
        public async Task<IEnumerable<EmployeeMovementsInfoDto>> Get()
        {
            var getEmployeeMovementsList = await _employeeMovementsService.GetAllEmployeeMovementsAsync();
            return _mapper.Map<IEnumerable<EmployeeMovementsInfoDto>>(getEmployeeMovementsList);
        }


        [HttpGet("GetEmployeeMovements/{id}")]
        public async Task<EmployeeMovementsInfoDto> GetEmployeeMovements(int id)
        {

            var getEmployeeMovements = await _employeeMovementsService.GetEmployeeMovements(id);
            if (getEmployeeMovements == null) throw new DataNotFoundException(nameof(PersonelHareketleri), id);
            return _mapper.Map<EmployeeMovementsInfoDto>(getEmployeeMovements);
        }

        [HttpPost("AddEmployeeMovements")]
        [ExceptionFilter]
        public async Task<bool> Post([FromBody] AddEmployeeMovementsDto input)
        {
            var result = await _employeeMovementsService.InsertEmployeeMovements(input);
            return result;
        }

        [HttpPut("UpdateEmployeeMovements")]
        [ExceptionFilter]
        public async Task<bool> Put([FromBody] AddEmployeeMovementsDto input)
        {
            var result = await _employeeMovementsService.UpdateEmployeeMovements(input);
            return result;
        }

        [HttpDelete("DeleteEmployeeMovements/{id}")]
        [ExceptionFilter]
        public async Task<bool> Delete(int id)
        {
            var result = await _employeeMovementsService.DeleteEmployeeMovements(id);
            return result;
        }
    }
}
