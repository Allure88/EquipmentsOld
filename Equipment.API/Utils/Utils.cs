using Microsoft.AspNetCore.Mvc;
using SharedCommon.Responces;
using System.Net;

namespace Equipment.API.Utils
{
    public static class Utils
    {
        public static ActionResult ToActionResult(this BaseResponse baseResponse, ControllerBase controllerBase)
        {
            if (baseResponse.Code == HttpStatusCode.OK)
            {
                return controllerBase.Ok(baseResponse);
            }
            else if (baseResponse.Code == HttpStatusCode.Unauthorized)
            {
                return controllerBase.Unauthorized(baseResponse);
            }
            else if (baseResponse.Code == HttpStatusCode.Conflict)
            {
                return controllerBase.Conflict(baseResponse);
            }
            else if (baseResponse.Code == HttpStatusCode.BadRequest)
            {
                return controllerBase.BadRequest(baseResponse);
            }
            else if (baseResponse.Code == HttpStatusCode.InternalServerError)
            {
                return controllerBase.BadRequest(baseResponse);
            }
            else
            {
                return controllerBase.Ok(baseResponse);
            }
        }
    }
}
