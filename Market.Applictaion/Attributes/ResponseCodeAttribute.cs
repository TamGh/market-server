using Market.Applictaion.Enums;
using System;

namespace Market.Applictaion.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ResponseCodeAttribute : Attribute
    {
        public ResponseCodeAttribute(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public ResponseType ResponseType { get; private set; }
    }
}
