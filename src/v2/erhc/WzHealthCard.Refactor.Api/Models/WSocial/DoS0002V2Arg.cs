
namespace WzHealthCard.Refactor.Api.Models.WSocial
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DoS0002V2Arg : Do1106Arg
    {
        [JsonProperty("idCardType")]
        public string idCardType { get; set; }

        [JsonProperty("idCardValue")]
        public string idCardValue { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("tel")]
        public string tel { get; set; }

        public override (bool isSuccessful, List<string> propertyKeys) Validation()
        {
            var (isSuccessful, propertyKeys) = base.Validation();

            if (string.IsNullOrEmpty(tel))
            {
                propertyKeys.Add("tel");
            }

            return (propertyKeys.Count == 0, propertyKeys);
        }
    }

    public class DoS0002V2Result : Do1106Result { }
}
