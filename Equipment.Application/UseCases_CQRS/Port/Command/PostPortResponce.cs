using DrawingBackend.Application.Models;

namespace Equipment.Application.UseCases_CQRS.Port.Command;

public class PostPortResponce(string responceMessage) : BaseResponse(responceMessage)
{
}
