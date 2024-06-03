using NextCBS.Module.Exceptions;

namespace NextCBS.Bank.Module.Exceptions
{
    public class UserNotFoundException : Exception, IAppException
    {
        public ExceptionCode ErrorCode => ExceptionCode.UserNotFound;
    }
}
