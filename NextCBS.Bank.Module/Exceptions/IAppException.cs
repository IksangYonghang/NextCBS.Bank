namespace NextCBS.Module.Exceptions;

public interface IAppException
{
    public ExceptionCode ErrorCode { get; }
}

public enum ExceptionCode
{
    ParameterNotFound, UserNotFound

}