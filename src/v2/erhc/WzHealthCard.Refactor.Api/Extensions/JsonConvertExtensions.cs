using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WzHealthCard.Refactor.Api.Extensions
{
    public static class JsonConvertExtensions
    {
        public static string ToJson(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(obj);
        }

        public static string ToJson(this object obj,bool iscamse)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver()
            }); ;
        }
    }

    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}