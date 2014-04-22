using System;

using Tokiota.Toolkit.XCutting.Helpers;

namespace Tokiota.Toolkit.XCutting.Log
{
    public abstract class LogBase : ILog
    {
        #region Public Methods and Operators

        public abstract void Debug(string message);

        public abstract void Debug(string message, Exception exception);

        public void DebugEx(Exception exception)
        {
            Ensure.Argument.NotNull(exception);

            Debug(exception.Message, exception);
        }

        public abstract void Error(string message);

        public abstract void Error(string message, Exception exception);

        public void ErrorEx(Exception exception)
        {
            Ensure.Argument.NotNull(exception);

            Error(exception.Message, exception);
        }

        public abstract void Fatal(string message);

        public abstract void Fatal(string message, Exception exception);

        public void FatalEx(Exception exception)
        {
            Ensure.Argument.NotNull(exception);

            Fatal(exception.Message, exception);
        }

        public abstract void Info(string message);

        public abstract void Info(string message, Exception exception);

        public void InfoEx(Exception exception)
        {
            Ensure.Argument.NotNull(exception);

            Info(exception.Message, exception);
        }

        public abstract void Warning(string message);

        public abstract void Warning(string message, Exception exception);

        public void WarningEx(Exception exception)
        {
            Ensure.Argument.NotNull(exception);

            Warning(exception.Message, exception);
        }

        #endregion

        #region Methods

        protected void ValidateArguments(string message, Exception exception)
        {
            ValidateMessage(message);
            Ensure.Argument.NotNull(exception);
        }

        protected void ValidateMessage(string message)
        {
            Ensure.Argument.NotNullOrEmpty(message);
        }

        #endregion
    }
}