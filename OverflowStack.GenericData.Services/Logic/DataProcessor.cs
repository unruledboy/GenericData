using System;
using System.Web.Hosting;
using OverflowStack.GenericData.Services.Logic.Core;
using OverflowStack.GenericData.SharedDomains;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.Services.Logic
{
    public class DataProcessor
    {
        public static BaseResponse Process(Request request)
        {
            BaseResponse response = null;
            var config = new ConfigReader(HostingEnvironment.MapPath("~/App_Data/ServerConfig.xml")).Read();
            var handlers = HandlerFactory.Find(request);
            try
            {
                foreach (var handler in handlers)
                {
                    DataResponse dataResponse;
                    if (handler.Process(request, config, out dataResponse))
                    {
                        response = dataResponse;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                var errorResponse = Utils.CreateResponse<ErrorResponse>();
                errorResponse.Message = ex.Message;
                errorResponse.Detail = ex.ToString();
                response = errorResponse;
            }
            return response;
        }
    }
}