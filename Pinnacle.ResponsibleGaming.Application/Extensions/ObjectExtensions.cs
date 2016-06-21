

namespace Pinnacle.ResponsibleGaming.Application.Extensions
{
    public static class ObjectExtensions
    {
        public static string SerializeAsKeyValues (this object obj)
        {
            var type = obj.GetType().Name;
            var serializedRequest = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            serializedRequest = serializedRequest.Replace(":", "=").Replace("\"", "").Replace("{", "").Replace("}", "").Replace(",", ", ");
            serializedRequest = "Request=" + type.Replace("Request", "") + ", " + serializedRequest;
            return serializedRequest;
        }
    }
}
