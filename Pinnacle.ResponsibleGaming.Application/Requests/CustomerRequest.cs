

using Newtonsoft.Json;

namespace Pinnacle.ResponsibleGaming.Application.Requests
{
    public class CustomerRequest
    {
       [JsonIgnore]
       public string CustomerId { get; set; }
    }
}
