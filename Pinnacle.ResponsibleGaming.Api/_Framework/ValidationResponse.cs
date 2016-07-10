using System.Collections.Generic;



namespace Pinnacle.ResponsibleGaming.Api._Framework
{
    public class ValidationResponse
    {
        public string Message { get; set; }
        public Dictionary<string, string[]> ModelState { get; set; }
    }
}