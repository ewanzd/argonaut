﻿namespace Argonaut.Core.Logging
{
    public class NLogLogger<T> : ILogger where T : class
    {
        private readonly NLog.Logger _logger;

        public NLogLogger()
        {
            _logger = NLog.LogManager.GetLogger(typeof(T).FullName);
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }
    }
}
