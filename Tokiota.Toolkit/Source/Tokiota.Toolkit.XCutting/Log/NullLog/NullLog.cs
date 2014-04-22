using System;

namespace Tokiota.Toolkit.XCutting.Log.NullLog
{
    public class NullLog : LogBase
    {
        #region Public Methods and Operators

        public override void Debug(string message)
        {
        }

        public override void Debug(string message, Exception exception)
        {
        }

        public override void Error(string message)
        {
        }

        public override void Error(string message, Exception exception)
        {
        }

        public override void Fatal(string message)
        {
        }

        public override void Fatal(string message, Exception exception)
        {
        }

        public override void Info(string message)
        {
        }

        public override void Info(string message, Exception exception)
        {
        }

        public override void Warning(string message)
        {
        }

        public override void Warning(string message, Exception exception)
        {
        }

        #endregion
    }
}