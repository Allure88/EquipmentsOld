using Equipment.API.Utils;
using Equipment.Application.UseCases_CQRS.Common.Commands.Material;
using Equipment.Application.UseCases_CQRS.Common.Commands.PipeType;
using Equipment.Application.UseCases_CQRS.Common.Queries.Material;
using Equipment.Application.UseCases_CQRS.Common.Queries.PipeType;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedCommon.CDB_EntityBodies;
using SharedCommon.Responces;

namespace Equipment.API.APIControllers.Commons
{
    [Route("api/pipeType")]
    [ApiController]
    public class PipeTypeController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                GetPipeTypeBodiesListResponse bodyList = await _mediator.Send(new GetPipyTypeBodiesListRequest());

                BaseResponse response = new(bodyList)
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
                GetPipeTypeResponse bodyEntity = await _mediator.Send(new GetPipyTypeRequest(id));


                BaseResponse response = new(bodyEntity.Body)
                {
                    Success = true,
                    Code = System.Net.HttpStatusCode.OK
                };

                if (bodyEntity.Body == null)
                {
                    response.Success = false;
                    response.Code = System.Net.HttpStatusCode.NotFound;
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
        public async Task<ActionResult> Add([FromBody] PipeTypeBody inputBody)
        {
            try
            {
                var command = await _mediator.Send(new PostAddPipeTypeRequest(inputBody));

                BaseResponse response = new(command.Body)
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
                var command = await _mediator.Send(new PostDeletePipeTypeRequest(id));
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
