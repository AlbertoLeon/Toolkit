namespace Tokiota.Toolkit.XCutting.IoC
{
    public interface IContainerProvider
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        IContainer Container { get; set; }

        #endregion
    }
}