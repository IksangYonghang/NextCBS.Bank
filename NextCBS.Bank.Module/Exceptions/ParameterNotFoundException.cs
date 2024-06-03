using NextCBS.Module.Exceptions;

namespace NextCBS.Bank.Module.Exceptions
{
    public class ParameterNotFoundException : Exception, IAppException
    {
        public ExceptionCode ErrorCode => ExceptionCode.ParameterNotFound;
    }
}
