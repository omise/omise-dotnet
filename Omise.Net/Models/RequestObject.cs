using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise
{
    /// <summary>
    /// Defines abstract base class for api request object
    /// </summary>
    public abstract class RequestObject : IValidatable
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        /// <value>Id</value>
        public string Id { get; set; }

        /// <summary>
        /// Defines whether the object is valid
        /// </summary>
        public virtual bool Valid { get; set; }

        /// <summary>
        /// Defines errors dictionary
        /// </summary>
        public abstract Dictionary<string, string> Errors { get; }

        /// <summary>
        /// Returns an instance of String representing the errors
        /// </summary>
        /// <returns></returns>
        public abstract string ToRequestParams();
    }
}

