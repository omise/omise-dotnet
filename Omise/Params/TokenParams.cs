using Newtonsoft.Json;

namespace Omise.Models
{
    public class CreateTokenParams : Params
    {
        [JsonProperty("card")]
        public CardParams Card { get; set; }
    }
}