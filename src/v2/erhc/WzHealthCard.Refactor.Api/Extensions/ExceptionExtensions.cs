
namespace WzHealthCard.Refactor.Api.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class ExceptionExtensions
    {
        public static string[] GetFullMessages(this Exception error)
        {
            var messages = new List<string>();

            for (; ; )
            {
                messages.Add(error.Message);

                if (error.InnerException == null) { break; }
                else { error = error.InnerException; }
            }

            return messages?.ToArray();
        }
    }
}
