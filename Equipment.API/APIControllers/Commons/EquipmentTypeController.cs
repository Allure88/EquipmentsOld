using Equipment.API.Utils;
using Equipment.Application.UseCases_CQRS.Common.Commands.Diametr;
using Equipment.Application.UseCases_CQRS.Common.Commands.EquipmentType;
using Equipment.Application.UseCases_CQRS.Common.Queries.Diametr;
using Equipment.Application.UseCases_CQRS.Common.Queries.EquipmentType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedCommon.CDB_EntityBodies;
using SharedCommon.Responces;

namespace Equipment.API.APIControllers.Commons
{
    [Route("api/equipmentType")]
    [ApiController]
    public class EquipmentTypeController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                GetEquipmentTypeBodiesListResponse bodyList = await _mediator.Send(new GetEquipmentTypeBodiesListRequest());

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
                GetEquipmentTypeResponse bodyEntity = await _mediator.Send(new GetEquipmentTypeRequest(id));


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
        public async Task<ActionResult> Add([FromBody] EquipmentTypeBody inputBody)
        {
            try
            {
                var command = await _mediator.Send(new PostAddEquipmentTypeRequest(inputBody));

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
                var command = await _mediator.Send(new PostDeleteEquipmentTypeRequest(id));
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
