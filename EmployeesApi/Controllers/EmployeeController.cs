using Common.classes.DTO;
using Domain.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        /// <summary>
        /// Crea una nueva aerolinea
        /// </summary>
        /// <returns>AirlineDTO</returns>

        [HttpPost("Add")]
        public async Task<IActionResult> Create(EmployeeCreateDTO employeeCreateDto)
        {
            try
            {
                EmployeeDTO employeeDto = await _employeeService.Create(employeeCreateDto);
                return CreatedAtAction(nameof(Create), employeeDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Consulta una lista de aerolinea
        /// </summary>
        /// <returns>List<AirlineDTO></returns>
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll(EmployeeFilterDTO employeeFilter)
        {
            try
            {
                List<EmployeeDTO> employees = await _employeeService.GetAll(employeeFilter);
                return new ObjectResult(employees);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Modifica una aerolinea 
        /// </summary>
        /// <returns>AirlineDTO</returns>
        [HttpPost("Update")]
        public async Task<IActionResult> Update(EmployeeDTO employeeDto)
        {
            try
            {
                employeeDto = await _employeeService.Update(employeeDto);
                return CreatedAtAction(nameof(Update), employeeDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
