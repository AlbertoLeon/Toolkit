namespace Tokiota.Toolkit.XCutting.Log
{
    public interface ILogFactory
    {
        #region Public Methods and Operators

        ILog GetLog(string name);

        #endregion
    }
}