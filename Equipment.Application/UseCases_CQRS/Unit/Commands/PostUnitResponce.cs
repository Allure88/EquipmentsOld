using DrawingBackend.Application.Models;

namespace Equipment.Application.UseCases_CQRS.Unit.Commands;

public class PostUnitResponce(string responceMessage) : BaseResponse(responceMessage)
{
}
