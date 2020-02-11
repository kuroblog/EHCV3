
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using System;
    using WzHealthCard.Refactor.Api.Models.Refactor;

    public class ErhcRemoteException : Exception
    {
        public ErhcRemoteException(string message) : base(message) { }

        public ErhcRemoteException(string message, Exception innerException) : base(message, innerException) { }

        public static void ThrowError(Exception innerException)
        {
            var (key, descOrName) = ResultCodes.RemoteError.GetInfo();
            throw new ErhcRemoteException(descOrName, innerException);
        }
    }
}
