using Equipment.API.Utils;
using Equipment.Application.UseCases_CQRS.ExternalProgramm.Commands;
using Equipment.Application.UseCases_CQRS.ExternalProgramm.Queries;
using Equipment.Application.UseCases_CQRS.SpecialFilter.Commands;
using Equipment.Application.UseCases_CQRS.SpecialFilter.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedCommon.Responces;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.PostBodies;

namespace Equipment.API.APIControllers
{
    [Route("api/special/filter")]
    [ApiController]
    public class PhysUnitBodyController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                GetSpecialFilterBodiesListResponce filtersResponse = await _mediator.Send(new GetSpecialFilterBodiesListRequest());

                BaseResponse response = new(filtersResponse)
                {
                    Success = true,
                    Code = System.Net.HttpStatusCode.OK
                };
                return response.ToActionResult(this);
            }
            catch (Exception ex)
            {
                string messageToUser = "";
                BaseResponse baseResponse = new(new { ex.Message })
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = messageToUser,
                    Success = false
                };
                return baseResponse.ToActionResult(this);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetById(long id)
        {
            try
            {
                GetSpecialFilterBodyResponse filter = await _mediator.Send(new GetSpecialFilterBodyRequest(id));


                BaseResponse response = new(filter)
                {
                    Success = true,
                    Code = System.Net.HttpStatusCode.OK
                };

                if (filter.PhysUnit == null)
                {
                    response = new(filter.PhysUnit)
                    {
                        Success = false,
                        Code = System.Net.HttpStatusCode.NotFound
                    };
                }

                return response.ToActionResult(this);
            }
            catch (Exception ex)
            {
                string messageToUser = "";
                BaseResponse baseResponse = new(new { ex.Message })
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = messageToUser,
                    Success = false
                };
                return baseResponse.ToActionResult(this);
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PhysUnitPostBody inputBody)
        {
            try
            {
                var command = await _mediator.Send(new PostAddSpecialFilterBodyCommand(inputBody));

                BaseResponse response = new(command.FilterUnit)
                {
                    Success = true,
                    Code = System.Net.HttpStatusCode.OK
                };
                return response.ToActionResult(this);
            }
            catch (Exception ex)
            {
                string messageToUser = "";
                BaseResponse baseResponse = new(new { ex.Message })
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = messageToUser,
                    Success = false
                };
                return baseResponse.ToActionResult(this);
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var command = await _mediator.Send(new PostDeleteSpecialFilterBodyCommand(id));
                BaseResponse response;
                if (command.Id != -1)
                {
                    response = new(command.Id)
                    {
                        Message = "Success deleted",
                        Success = true,
                        Code = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    response = new(command.Id)
                    {
                        Message = "Denied to delete",
                        Success = true,
                        Code = System.Net.HttpStatusCode.NotFound
                    };
                }
                return response.ToActionResult(this);
            }
            catch (Exception ex)
            {
                string messageToUser = "";
                BaseResponse baseResponse = new(new { ex.Message })
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = messageToUser,
                    Success = false
                };
                return baseResponse.ToActionResult(this);
            }
        }
    }
}
