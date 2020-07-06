namespace Argonaut.Core.Logging
{
    public class NLogLoggerFactory : ILoggerFactory
    {
        public ILogger Create<T>() where T : class
        {
            return new NLogLogger<T>();
        }
    }
}
