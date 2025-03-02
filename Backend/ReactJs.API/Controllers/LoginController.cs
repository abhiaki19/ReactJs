using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity.Data;
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
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService _loginService;
        private readonly IMemoryCache _memoryCache;
        public LoginController(ILogger<LoginController> logger, ILoginService loginService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _loginService = loginService;
            _memoryCache = memoryCache;
        }
       
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                string message = "";
               

                try
                {
                    var res = await _loginService.Login(model, cancellationToken);
                    if (res != null)
                    {
                        var response = new ResponseModel<LoginResponce>
                        {
                            Success = true,
                            Message = "employee login successfully",
                            Data = res
                        };
                    return Ok(response);
                    }
                    else
                    {
                        var response = new ResponseModel<LoginResponce>
                        {
                            Success = false,
                            Message = "Username and Password are incorrect. please try again!",
                            Data = res
                        };
                        return Ok(response);
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while login employee");
                    message = $"An error occurred while login employee- " + ex.Message;

                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<LoginRequest>
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


    }
}
