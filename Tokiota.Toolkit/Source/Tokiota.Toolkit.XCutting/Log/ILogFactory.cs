namespace Tokiota.Toolkit.XCutting.Log
{
    public interface ILogFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the log. Factory method
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        ILog GetLog(string name);

        #endregion
    }
}