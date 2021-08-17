using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DeletePage
    {
        /// <summary>
        /// Constructor without arguments: added for class initializations using class literals.
        /// </summary>
        public DeletePage()
        {
        }

        [JsonProperty("archived")]
        public bool IsArchived { get; set; } = true;

        public Dictionary<string, PropertyValue> Properties { get; set; } = new Dictionary<string, PropertyValue>();
    }
}
