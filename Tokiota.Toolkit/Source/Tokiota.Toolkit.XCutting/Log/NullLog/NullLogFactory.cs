namespace Tokiota.Toolkit.XCutting.Log.NullLog
{
    public class NullLogFactory : ILogFactory
    {
        #region Public Methods and Operators

        public ILog GetLog(string name)
        {
            return new NullLog();
        }

        #endregion
    }
}