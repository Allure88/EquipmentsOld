using Equipment.API.Utils;
using Equipment.Application.UseCases_CQRS.Common.Commands.StageType;
using Equipment.Application.UseCases_CQRS.Common.Queries.StageType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedCommon.CDB_EntityBodies;
using SharedCommon.Responces;

namespace Equipment.API.APIControllers.Commons
{
    [Route("api/stageType")]
    [ApiController]
    public class StageTypeController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                GetStageTypeBodiesListResponse bodyList = await _mediator.Send(new GetStageTypeBodiesListRequest());

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
                GetStageTypeResponse bodyEntity = await _mediator.Send(new GetStageTypeRequest(id));


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
        public async Task<ActionResult> Add([FromBody] StageTypeBody inputBody)
        {
            try
            {
                var command = await _mediator.Send(new PostAddStageTypeRequest(inputBody));

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
                var command = await _mediator.Send(new PostDeleteStageTypeRequest(id));
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
