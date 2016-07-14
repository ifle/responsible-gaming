// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Pinnacle.ResponsibleGaming.ApiClient.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class ValueProviderResult
    {
        /// <summary>
        /// Initializes a new instance of the ValueProviderResult class.
        /// </summary>
        public ValueProviderResult() { }

        /// <summary>
        /// Initializes a new instance of the ValueProviderResult class.
        /// </summary>
        public ValueProviderResult(string attemptedValue = default(string), string culture = default(string), object rawValue = default(object))
        {
            AttemptedValue = attemptedValue;
            Culture = culture;
            RawValue = rawValue;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AttemptedValue")]
        public string AttemptedValue { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Culture")]
        public string Culture { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RawValue")]
        public object RawValue { get; private set; }

    }
}