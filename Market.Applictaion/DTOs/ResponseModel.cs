using Market.Applictaion.Enums;
using Market.Applictaion.Resources;

namespace Market.Applictaion.DTOs
{
    public class ResponseModel
    {
        public ResponseType ResponseType { get; protected set; }
        public string Message { get; protected set; }
        public static ResponseModel Create(ResponseCode responseCode)
        {
            var resource = responseCode.GetResource();
            return new ResponseModel
            {
                ResponseType = resource.ResponseType,
                Message = resource.Message
            };


        }
        public static ResponseModel Create(ResponseType responseType, string message)
        {
            return new ResponseModel
            {
                ResponseType = responseType,
                Message = message
            };
        }
    }

    public class ResponseModel<TData> : ResponseModel
    {
        public TData Data { get; private set; }

        public static ResponseModel<TData> Create(ResponseCode responseCode, TData data = default)
        {

            var resource = responseCode.GetResource();
            return new ResponseModel<TData>
            {
                ResponseType = resource.ResponseType,
                Message = resource.Message,
                Data = data
            };
        }

        public static ResponseModel<TData> Create(ResponseType responseType, TData data = default, string message = null)
        {
            return new ResponseModel<TData>
            {
                ResponseType = responseType,
                Message = message,
                Data = data
            };
        }

        public static ResponseModel<TData> Create(TData data) => Create(ResponseCode.Success, data);
    }
}
