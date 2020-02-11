
namespace WzHealthCard.Refactor.Api.Models.WSocial
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using WzHealthCard.Refactor.Api.Models.Refactor;

    public class DoS0003V2Arg : ErhcmemberApplyQueryArgument
    {
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

    public class DoS0003V2Result : Do1106Result { }
}
