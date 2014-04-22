using System.Threading.Tasks;

namespace Tokiota.Toolkit.XCutting.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork
    {
        #region Public Methods and Operators

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();

        #endregion
    }
}