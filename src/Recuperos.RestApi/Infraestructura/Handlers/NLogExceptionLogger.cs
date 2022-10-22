using System;
using System.Diagnostics;
using System.Web.Http.ExceptionHandling;
using Microsoft.Owin.Logging;
using NLog;

namespace Recuperos.RestApi.Infraestructura.Handlers
{
    public class NLogExceptionLogger : ExceptionLogger
    {
    }

    public class NLogFactory : ILoggerFactory
    {
        readonly Func<TraceEventType, LogLevel> _getLogLevel;

        
        public NLogFactory()
        {
            this._getLogLevel = DefaultGetLogLevel;
        }

       
        public NLogFactory(Func<TraceEventType, LogLevel> getLogLevel)
        {
            this._getLogLevel = getLogLevel;
        }

      
        static LogLevel DefaultGetLogLevel(TraceEventType traceEventType)
        {
            switch (traceEventType)
            {
                case TraceEventType.Critical:
                    return LogLevel.Fatal;
                case TraceEventType.Error:
                    return LogLevel.Error;
                case TraceEventType.Warning:
                    return LogLevel.Warn;
                case TraceEventType.Information:
                    return LogLevel.Info;
                case TraceEventType.Verbose:
                    return LogLevel.Trace;
                case TraceEventType.Start:
                    return LogLevel.Debug;
                case TraceEventType.Stop:
                    return LogLevel.Debug;
                case TraceEventType.Suspend:
                    return LogLevel.Debug;
                case TraceEventType.Resume:
                    return LogLevel.Debug;
                case TraceEventType.Transfer:
                    return LogLevel.Debug;
                default:
                    throw new ArgumentOutOfRangeException("traceEventType");
            }
        }

      
        public Microsoft.Owin.Logging.ILogger Create(string name)
        {
            return new Logger(name, this._getLogLevel);
        }

       
        class Logger : Microsoft.Owin.Logging.ILogger
        {
            readonly Func<TraceEventType, LogLevel> _getLogLevel;

            readonly NLog.Logger _logger;

            internal Logger(string name, Func<TraceEventType, LogLevel> getLogLevel)
            {
                this._getLogLevel = getLogLevel;
                this._logger = LogManager.GetLogger(name);
            }

            public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
            {
                var level = this._getLogLevel(eventType);

                
                if (state == null)
                {
                    return this._logger.IsEnabled(level);
                }
                if (!this._logger.IsEnabled(level))
                {
                    return false;
                }

                var logEvent = LogEventInfo.Create(level, _logger.Name, exception, _logger.Factory.DefaultCultureInfo, formatter(state, exception));
                logEvent.Properties["EventId"] = eventId;
                _logger.Log(logEvent);

                return true;
            }
        }
    }
}