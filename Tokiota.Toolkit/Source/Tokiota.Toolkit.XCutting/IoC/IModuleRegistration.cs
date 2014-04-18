namespace Tokiota.Toolkit.XCutting.IoC
{
    /// <summary>
    /// public interface for register operation to the builder in IoC context
    /// </summary>
    public interface IModuleRegistration
    {
        #region Public Methods and Operators

        /// <summary>
        /// Registers the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        void Register(IBuilder builder);

        #endregion
    }
}
