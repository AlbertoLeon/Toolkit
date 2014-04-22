using System.Threading.Tasks;

namespace Tokiota.Toolkit.XCutting.Repository
{
    public interface IRepository<TData, TKey>
    {
        #region Public Methods and Operators

        /// <summary>
        /// Creates the specified new data.
        /// </summary>
        /// <param name="newData">The new data.</param>
        void Create(TData newData);

        /// <summary>
        /// Dirties the specified to modified.
        /// </summary>
        /// <param name="toModified">To modified.</param>
        void Dirty(TData toModified);

        /// <summary>
        /// Finds the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TData> FindByIdAsync(TKey id);

        /// <summary>
        /// Removes the specified to delete.
        /// </summary>
        /// <param name="toDelete">To delete.</param>
        void Remove(TData toDelete);

        #endregion
    }
}