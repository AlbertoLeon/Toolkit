namespace Tokiota.Toolkit.XCutting.Mapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TIn">The type of the in.</typeparam>
    /// <typeparam name="TOut">The type of the out.</typeparam>
    public interface IMapper<in TIn, out TOut>
    {
        #region Public Methods and Operators

        /// <summary>
        /// Maps the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        TOut Map(TIn input);

        #endregion
    }
}