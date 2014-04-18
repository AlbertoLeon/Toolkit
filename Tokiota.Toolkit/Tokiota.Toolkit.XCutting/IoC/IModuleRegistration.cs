namespace Tokiota.Toolkit.XCutting.IoC
{
    public interface IModuleRegistration
    {
        #region Public Methods and Operators

        void Register(IBuilder builder);

        #endregion
    }
}
