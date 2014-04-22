using System;

namespace Tokiota.Toolkit.XCutting.Log
{
    public interface ILog
    {
        #region Public Methods and Operators

        void Debug(string message);

        void Debug(string message, Exception exception);

        void DebugEx(Exception exception);

        void Error(string message);

        void Error(string message, Exception exception);

        void ErrorEx(Exception exception);

        void Fatal(string message);

        void Fatal(string message, Exception exception);

        void FatalEx(Exception exception);

        void Info(string message);

        void Info(string message, Exception exception);

        void InfoEx(Exception exception);

        void Warning(string message);

        void Warning(string message, Exception exception);

        void WarningEx(Exception exception);

        #endregion
    }
}