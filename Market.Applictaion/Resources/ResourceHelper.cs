using Market.Applictaion.Attributes;
using Market.Applictaion.Enums;
using Market.Applictaion.Exstendions;

namespace Market.Applictaion.Resources
{
    public static class ResourceHelper
    {
        public static (ResponseType ResponseType, string Message) GetResource(this ResponseCode responseCode)
        {

            var codeAttribute = responseCode.GetAttribute<ResponseCodeAttribute>();
            var message = GetResourceMessageValue(responseCode.ToString());

            return (codeAttribute.ResponseType, message);
        }

        public static string GetResourceMessage(this ResponseCode responseCode) => GetResource(responseCode).Message;

        private static string GetResourceMessageValue(string key) => ResourceMessages.ResourceManager.GetString(key) ?? key;
    }
}
