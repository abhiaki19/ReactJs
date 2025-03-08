using Asp.Versioning;
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
    public class ContactUsController : Controller
    {
        private readonly ILogger<ContactUsController> _logger;
        private readonly IContactUsService _contactUsService;
        public ContactUsController(ILogger<ContactUsController> logger, IContactUsService contactUsService)
        {
            _logger = logger;
            _contactUsService = contactUsService; 
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactUsRequest model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                string message = ""; 
                try
                {
                    var data = await _contactUsService.Create(model, cancellationToken);

                    var response = new ResponseModel<ContactUsResponse>
                    {
                        Success = true,
                        Message = "Thank you for Contact Us.",
                        Data = data
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while contact us");
                    message = $"An error occurred while contact us- " + ex.Message;

                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<ContactUsRequest>
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

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel<ContactUsRequest>
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
