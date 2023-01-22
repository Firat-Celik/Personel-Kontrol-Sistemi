using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonelKontrol.Application.Dtos;
using PersonelKontrol.Domain.Entities.Concrates;
using PersonelKontrol.Presentation.Exceptions;
using PersonelKontrol.Presentation.Filters;
using PersonelKontrol.Service.Interface;
using PersonelKontrol.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonelKontrol.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeMovementsService _employeeMovementService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IEmployeeMovementsService employeeMovementService, IMapper mapper)
        {
            _employeeService = employeeService;
            _employeeMovementService = employeeMovementService;
            _mapper = mapper;
        }

        [HttpGet("GetEmployeeList")]
        [ExceptionFilter]
        public async Task<IEnumerable<EmployeeInfoDto>> Get()
        {
         var getEmployeeList= await _employeeService.GetAllEmployeeAsync();        
            return _mapper.Map<IEnumerable<EmployeeInfoDto>>(getEmployeeList); 
        }

    
        [HttpGet("GetEmployee/{id}")] 
        public  async Task<EmployeeInfoDto> GetEmployee(int id)
        {
                        
            var getEmployee = await _employeeService.GetEmployee(id);
            if(getEmployee ==null) throw new DataNotFoundException(nameof(Personel), id);
            return _mapper.Map<EmployeeInfoDto>(getEmployee);
        }
         
        [HttpPost("AddEmployee")]
        [ExceptionFilter]
        public async Task<bool> Post ([FromBody] Personel input )
        {
            var result= await _employeeService.InsertEmployee(input);
            return result;
        }
         
        [HttpPut("UpdateEmployee")]
        [ExceptionFilter]
        public async Task<bool> Put([FromBody] Personel input)
        {            
            var result = await _employeeService.UpdateEmployee(input);
            return result;
        }
         
        [HttpDelete("DeleteEmployee/{id}")]
        [ExceptionFilter]
        public async Task<bool> Delete(int id)
        {
            // Transection yapısı uyarlamak için zamanım yetmedi. Service Yapısında entegre etmek için araştırılacak..
            var getEmployeeMovement = await _employeeMovementService.GetEmployeeMovementListByPersonelId(id);
            if (getEmployeeMovement != null && getEmployeeMovement.Count() > 0)
            {
                foreach (var item in getEmployeeMovement)
                {
                      await _employeeMovementService.DeleteEmployeeMovements(item.Id);              
                }
            }
            var result = await _employeeService.DeleteEmployee(id);
            return result;
        }
    }
}
