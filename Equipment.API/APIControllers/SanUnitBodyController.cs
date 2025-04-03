using Equipment.API.Utils;
using Equipment.Application.UseCases_CQRS.Filters.Commands;
using Equipment.Application.UseCases_CQRS.Filters.Queries;
using Equipment.Application.UseCases_CQRS.SpecialFilter.Commands;
using Equipment.Application.UseCases_CQRS.SpecialFilter.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedCommon.Responces;
using SharedCommon.TechSchemaDomain.PostDTO.Units;


namespace Equipment.API.APIControllers
{
    [Route("api/filter")]
    [ApiController]
    public class SanUnitBodyController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                GetFilterBodiesListResponce filtersResponse = await _mediator.Send(new GetFilterBodiesListRequest());

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
        public async Task<ActionResult> GetId(long id)
        {
            try
            {
                GetFilterBodyResponse filter = await _mediator.Send(new GetFilterBodyRequest(id));


                BaseResponse response = new(filter)
                {
                    Success = true,
                    Code = System.Net.HttpStatusCode.OK
                };

                if (filter.Body == null)
                {
                    response = new(filter.Body)
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
        public async Task<ActionResult> Post([FromBody] FilterUnitPostBody inputBody)
        {
            try
            {
                var command = await _mediator.Send(new PostAddFilterUnitBodyCommand(inputBody));

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
                var command = await _mediator.Send(new PostDeleteSanUnitBodyCommand(id));
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
