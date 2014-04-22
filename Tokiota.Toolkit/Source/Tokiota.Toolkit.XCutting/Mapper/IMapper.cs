namespace Tokiota.Toolkit.XCutting.Mapper
{
    public interface IMapper<in TIn, out TOut>
    {
        #region Public Methods and Operators

        TOut Map(TIn input);

        #endregion
    }
}