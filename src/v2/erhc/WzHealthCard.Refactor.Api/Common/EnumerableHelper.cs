using System.Collections;
using System.Text;

namespace WzHealthCard.Refactor.Api.Common
{
    public static class EnumerableHelper
    {
        /// <summary>连接到文本</summary>
        /// <param name="em"> 集合本身 </param>
        /// <param name="sp"> </param>
        /// <returns> </returns>
        public static string LinkToString(this IEnumerable em, char sp = ',')
        {
            if (em == null)
                return (string)null;
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = true;
            foreach (object obj in em)
            {
                if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
                {
                    if (flag)
                        flag = false;
                    else
                        stringBuilder.Append(sp);
                    stringBuilder.Append(obj);
                }
            }
            return stringBuilder.ToString();
        }
    }
}