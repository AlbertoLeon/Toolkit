using System.Threading.Tasks;

namespace Tokiota.Toolkit.XCutting.Repository
{
    public interface IRepository<TData, TKey>
    {
        #region Public Methods and Operators

        void Create(TData newData);

        void Dirty(TData toModified);

        Task<TData> FindByIdAsync(TKey id);

        void Remove(TData toDelete);

        #endregion
    }
}