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
    public class TeamController : Controller
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ITeamService _TeamService;
        private readonly IMemoryCache _memoryCache;
        public TeamController(ILogger<TeamController> logger, ITeamService TeamService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _TeamService = TeamService;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                var lstTeam = await _TeamService.GetAll(cancellationToken);

                var response = new ResponseModel<IEnumerable<TeamResponse>>
                {
                    Success = true,
                    Message = "Teams retrieved successfully",
                    Data = lstTeam
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving Teams");

                var errorResponse = new ResponseModel<IEnumerable<TeamRequest>>
                {
                    Success = false,
                    Message = "Error retrieving Teams",
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
                var Team = new TeamResponse();

                // Attempt to retrieve the Team from the cache
                if (_memoryCache.TryGetValue($"Team_{id}", out TeamResponse cachedTeam))
                {
                    Team = cachedTeam;
                }
                else
                {
                    // If not found in cache, fetch the Team from the data source
                    Team = await _TeamService.GetById(id, cancellationToken);

                    if (Team != null)
                    {
                        // Cache the Team with an expiration time of 10 minutes
                        _memoryCache.Set($"Team_{id}", Team, TimeSpan.FromMinutes(10));
                    }
                }

                var response = new ResponseModel<TeamResponse>
                {
                    Success = true,
                    Message = "Team retrieved successfully",
                    Data = Team
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex.Message == "No data found")
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseModel<TeamRequest>
                    {
                        Success = false,
                        Message = "Team not found",
                        Error = new ErrorModel
                        {
                            Code = "NOT_FOUND",
                            Message = "Team not found"
                        }
                    });
                }

                _logger.LogError(ex, $"An error occurred while retrieving the Team");

                var errorResponse = new ResponseModel<TeamRequest>
                {
                    Success = false,
                    Message = "Error retrieving Team",
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
        public async Task<IActionResult> Create(TeamRequest model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                if (await _TeamService.IsExists("Teamname", model.TeamName, cancellationToken))
                {
                    message = $"The Team Teamname- '{model.TeamName}' already exists";
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel<TeamRequest>
                    {
                        Success = false,
                        Message = message,
                        Error = new ErrorModel
                        {
                            Code = "DUPLICATE_Teamname",
                            Message = message
                        }
                    });
                }


                try
                {
                    var data = await _TeamService.Create(model, cancellationToken);

                    var response = new ResponseModel<TeamResponse>
                    {
                        Success = true,
                        Message = "Team created successfully",
                        Data = data
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while adding the Team");
                    message = $"An error occurred while adding the Team- " + ex.Message;

                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<TeamRequest>
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

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel<TeamRequest>
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
        public async Task<IActionResult> Edit(List<TeamRequest> model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                //if (await _TeamService.IsExistsForUpdate(model.Id, "Teamname", model.TeamName, cancellationToken))
                //{
                //    message = $"The Team Teamname- '{model.TeamName}' already exists";
                //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel
                //    {
                //        Success = false,
                //        Message = message,
                //        Error = new ErrorModel
                //        {
                //            Code = "DUPLICATE_NAME",
                //            Message = message
                //        }
                //    });
                //}


                try
                {
                    bool partialSave=false;
                    var lst = await _TeamService.GetAll(cancellationToken);
                    foreach (var item in model)
                    {
                        item.Id = item.Id > 0 ? item.Id : 0;
                        if (item.Id > 0)
                        {
                            if (!await _TeamService.IsExistsForUpdate(item.Id, "Teamname", item.TeamName, cancellationToken))
                            {
                                await _TeamService.Update(item, cancellationToken);
                            }
                            else
                            {
                                partialSave = true;
                            }
                        }
                        else
                        {
                            if (!await _TeamService.IsExists("Teamname", item.TeamName, cancellationToken))
                            {
                             await _TeamService.Create(item, cancellationToken);

                            }
                            else
                            {
                                partialSave = true;
                            }
                        }
                    }
                    // Delete object from database
                    if (lst!=null&&lst.Count() > 0)
                    {
                        var result = lst?.Where(p => model.All(p2 => p2.Id != p.Id));

                        foreach (var item in result)
                        {
                            await _TeamService.Delete(item.Id, cancellationToken);
                        }
                    }
                    // Remove data from cache by key
                    //_memoryCache.Remove($"Team_{model.Id}");

                    var response = new ResponseModel
                    {
                        Success = true,
                        Message = partialSave? "Team list partially saved successfully" : "Team list successfully saved"
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while updating the Team");
                    message = $"An error occurred while updating the Team- " + ex.Message;

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
                await _TeamService.Delete(id, cancellationToken);

                // Remove data from cache by key
                _memoryCache.Remove($"Team_{id}");

                var response = new ResponseModel
                {
                    Success = true,
                    Message = "Team deleted successfully"
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
                        Message = "Team not found",
                        Error = new ErrorModel
                        {
                            Code = "NOT_FOUND",
                            Message = "Team not found"
                        }
                    });
                }

                _logger.LogError(ex, "An error occurred while deleting the Team");

                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel
                {
                    Success = false,
                    Message = "Error deleting the Team",
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
