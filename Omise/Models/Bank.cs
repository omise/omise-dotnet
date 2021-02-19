using Newtonsoft.Json;

namespace Omise.Models
{
    public class Bank
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("active")]

        public bool Active { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var another = obj as Bank;
            if (another == null) return false;

            return base.Equals(obj) &&
                object.Equals(this.Code, another.Code) &&
                object.Equals(this.Name, another.Name) &&
                object.Equals(this.Active, another.Active) &&
                true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Code.GetHashCode();
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Active.GetHashCode();

                return hash;
            }
        }
    }
}
