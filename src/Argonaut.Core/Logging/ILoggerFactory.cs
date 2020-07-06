namespace Argonaut.Core.Logging
{
    public interface ILoggerFactory
    {
        ILogger Create<T>() where T : class;
    }
}
