
namespace WzHealthCard.Refactor.Api.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceNullValue(this string arg)
        {
            return string.IsNullOrEmpty(arg) ? string.Empty : arg;
        }
    }
}
