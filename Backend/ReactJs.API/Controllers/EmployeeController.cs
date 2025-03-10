using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ReactJs.API.Helpers;
using ReactJs.Core.Interfaces.IServices;
using ReactJs.Core.Models;
using ReactJs.Core.Services;

namespace ReactJs.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IMemoryCache _memoryCache;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _employeeService = employeeService;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        [AllowAnonymous]
        [Authorize]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                var lstEmployee = await _employeeService.GetAll(cancellationToken);

                var response = new ResponseModel<IEnumerable<EmployeeResponse>>
                {
                    Success = true,
                    Message = "employees retrieved successfully",
                    Data = lstEmployee
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving employees");

                var errorResponse = new ResponseModel<IEnumerable<EmployeeRequest>>
                {
                    Success = false,
                    Message = "Error retrieving employees",
                    Error = new ErrorModel
                    {
                        Code = "ERROR_CODE",
                        Message = ex.Message
                    }
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            try
            {
                var employee = new EmployeeResponse();

                // Attempt to retrieve the employee from the cache
                if (_memoryCache.TryGetValue($"employee_{id}", out EmployeeResponse cachedEmployee))
                {
                    employee = cachedEmployee;
                }
                else
                {
                    // If not found in cache, fetch the employee from the data source
                    employee = await _employeeService.GetById(id, cancellationToken);

                    if (employee != null)
                    {
                        // Cache the employee with an expiration time of 10 minutes
                        _memoryCache.Set($"employee_{id}", employee, TimeSpan.FromMinutes(10));
                    }
                }

                var response = new ResponseModel<EmployeeResponse>
                {
                    Success = true,
                    Message = "employee retrieved successfully",
                    Data = employee
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex.Message == "No data found")
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseModel<EmployeeRequest>
                    {
                        Success = false,
                        Message = "employee not found",
                        Error = new ErrorModel
                        {
                            Code = "NOT_FOUND",
                            Message = "employee not found"
                        }
                    });
                }

                _logger.LogError(ex, $"An error occurred while retrieving the employee");

                var errorResponse = new ResponseModel<EmployeeRequest>
                {
                    Success = false,
                    Message = "Error retrieving employee",
                    Error = new ErrorModel
                    {
                        Code = "ERROR_CODE",
                        Message = ex.Message
                    }
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequest model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                if (await _employeeService.IsExists("Username", model.Username, cancellationToken))
                {
                    message = $"The employee username- '{model.Username}' already exists";
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel<EmployeeRequest>
                    {
                        Success = false,
                        Message = message,
                        Error = new ErrorModel
                        {
                            Code = "DUPLICATE_USERNAME",
                            Message = message
                        }
                    });
                }


                try
                {
                    var data = await _employeeService.Create(model, cancellationToken);

                    var response = new ResponseModel<EmployeeResponse>
                    {
                        Success = true,
                        Message = "employee created successfully",
                        Data = data
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while adding the employee");
                    message = $"An error occurred while adding the employee- " + ex.Message;

                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<EmployeeRequest>
                    {
                        Success = false,
                        Message = message,
                        Error = new ErrorModel
                        {
                            Code = "ADD_ROLE_ERROR",
                            Message = message
                        }
                    });
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel<EmployeeRequest>
            {
                Success = false,
                Message = "Invalid input",
                Error = new ErrorModel
                {
                    Code = "INPUT_VALIDATION_ERROR",
                    Message = ModelStateHelper.GetErrors(ModelState)
                }
            });
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(EmployeeRequest model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                if (await _employeeService.IsExistsForUpdate(model.Id, "Username", model.Username, cancellationToken))
                {
                    message = $"The employee username- '{model.Username}' already exists";
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel
                    {
                        Success = false,
                        Message = message,
                        Error = new ErrorModel
                        {
                            Code = "DUPLICATE_NAME",
                            Message = message
                        }
                    });
                }


                try
                {
                    await _employeeService.Update(model, cancellationToken);

                    // Remove data from cache by key
                    _memoryCache.Remove($"employee_{model.Id}");

                    var response = new ResponseModel
                    {
                        Success = true,
                        Message = "employee updated successfully"
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while updating the employee");
                    message = $"An error occurred while updating the employee- " + ex.Message;

                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel
                    {
                        Success = false,
                        Message = message,
                        Error = new ErrorModel
                        {
                            Code = "UPDATE_ROLE_ERROR",
                            Message = message
                        }
                    });
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel
            {
                Success = false,
                Message = "Invalid input",
                Error = new ErrorModel
                {
                    Code = "INPUT_VALIDATION_ERROR",
                    Message = ModelStateHelper.GetErrors(ModelState)
                }
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _employeeService.Delete(id, cancellationToken);

                // Remove data from cache by key
                _memoryCache.Remove($"employee_{id}");

                var response = new ResponseModel
                {
                    Success = true,
                    Message = "employee deleted successfully"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex.Message == "No data found")
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseModel
                    {
                        Success = false,
                        Message = "employee not found",
                        Error = new ErrorModel
                        {
                            Code = "NOT_FOUND",
                            Message = "employee not found"
                        }
                    });
                }

                _logger.LogError(ex, "An error occurred while deleting the employee");

                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel
                {
                    Success = false,
                    Message = "Error deleting the employee",
                    Error = new ErrorModel
                    {
                        Code = "DELETE_ROLE_ERROR",
                        Message = ex.Message
                    }
                });

            }
        }
    }
}
